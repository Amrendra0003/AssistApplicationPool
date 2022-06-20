using Healthware.Core.Common.Session;
using Healthware.Core.Configurations;
using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Repository;
using Healthware.Core.Security;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using HealthWare.ActiveASSIST.Services.Mapper;
using HealthWare.ActiveASSIST.Web.Authentication.JwtBearer;
using HealthWare.ActiveASSIST.Web.Common.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IAuthenticationService
    {
        Task<Result<AuthenticateResponse>> Authenticate(Authenticate authenticate);
        Task<Result<AuthenticateResponse>> LoginWithoutOTP(Authenticate authenticate);
        Task<Result<MessageDto>> SendOTP(SendOTP sendOtp);
        Task<Result<AuthenticateResponse>> ValidateOTP(ValidateOTP validateOtp);
        Result<AuthenticateResponse> ForgotMyPassword(ForgotPassword forgotPassword);
        Task<Result<MessageDto>> UpdateNewPassword(ResetPassword resetPassword);
        Task<Result<MessageDto>> Logout(long userId);
        Task<Result<MessageDto>> ChangePassword(ChangePassword changePassword);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IUserClaimsPrincipalFactory<User> _claimsPrincipalFactory;
        private readonly IEmailService _emailService;
        private readonly IUserAccountMapper _userAccountMapper;
        private readonly IUserRepository _userRepository;
        private readonly ISessionService<PatientDbContext> _sessionService;
        private readonly ISessionActivityRepository<PatientDbContext> _sessionActivityRepository;
        private readonly IUserHasRolesRepository _userHasRolesRepository;
        private readonly IRoleRepository _roleRepository;
        private HttpContext _httpContext;
        private readonly IPasswordPolicyService _passwordPolicyService;
        private readonly IPasswordPolicyRepository _passwordPolicyRepository;

        public AuthenticationService(IJwtHelper jwtHelper,
            IUserClaimsPrincipalFactory<User> claimsPrincipalFactory, IPasswordPolicyService passwordPolicyService,
            IEmailService emailService, IUserAccountMapper userAccountMapper, IUserRepository userRepository, ISessionService<PatientDbContext> sessionService, ISessionActivityRepository<PatientDbContext> sessionActivityRepository, IUserHasRolesRepository userHasRolesRepository, IRoleRepository roleRepository, IHttpContextAccessor contextAccessor, IPasswordPolicyRepository passwordPolicyRepository)
        {
            _jwtHelper = jwtHelper;
            _claimsPrincipalFactory = claimsPrincipalFactory;
            _emailService = emailService;
            _userAccountMapper = userAccountMapper;
            _userRepository = userRepository;
            _sessionService = sessionService;
            _sessionActivityRepository = sessionActivityRepository;
            _userHasRolesRepository = userHasRolesRepository;
            _roleRepository = roleRepository;
            _passwordPolicyRepository = passwordPolicyRepository;
            _httpContext = contextAccessor.HttpContext;
            _passwordPolicyService = passwordPolicyService;
        }

        public async Task<Result<AuthenticateResponse>> Authenticate(Authenticate authenticate)
        {
            _httpContext.Request.Headers.TryGetValue("tenant", out var userTenantId);
            if (await _userRepository.IsUserExistsByTenantId(authenticate.EmailAddress, Convert.ToInt64(userTenantId)))
            {
                var user = await _userRepository.GetUserByEmailAddressAndTenantId(authenticate.EmailAddress, userTenantId);
                var getUserLoginHistory = await _passwordPolicyService.GetUserLoginHistory(user.Id);

                var tenantId = user.TenantId;
                var passwordPolicy = await _passwordPolicyService.GetPasswordPolicy(tenantId);
                bool isTimeExpired = true;
                if (getUserLoginHistory.IsNotNull())
                {
                    isTimeExpired = !(DateTime.UtcNow < getUserLoginHistory.ExpireTime);
                }
                if (user.IsActive.Equals(true) || isTimeExpired)
                {
                    if (PasswordEncryptionDecryption.ValidatePassword(authenticate.Password, user.Password))
                    {
                        if (user.IsActive.Equals(false) || getUserLoginHistory.IsNotNull())
                        {
                            getUserLoginHistory.NoOfAttempts = 0;
                            user.IsActive = true;
                            await _userRepository.Update(user);
                            await _passwordPolicyRepository.UpdateLoginHistory(getUserLoginHistory);
                        }
                        AuthenticateResponse authenticateResponse;
                        await _userRepository.UpdateIsUsernamePasswordValidated(user, true);
                        authenticateResponse = _userAccountMapper.MapFrom(user);
                        authenticateResponse.TenantId = tenantId;
                        if (PropertyValues.isOTPEnabled())
                        {
                            return new Result<AuthenticateResponse>() { Data = authenticateResponse };
                        }

                        var userHasRole = await _userHasRolesRepository.GetUserRoleByUserId(user.Id);
                        var role = await _roleRepository.FindByIdAsync(userHasRole.Role.Id.ToString(), cancellationToken: CancellationToken.None);

                        var firstName = user.FirstName;
                        var lastName = user.LastName;

                        var sessionActivity = await _sessionService.InitiateSession(user);
                        var token = await GetAccessToken(user, role.RoleName, sessionActivity.Id);
                        authenticateResponse = _userAccountMapper.MapFrom(user, firstName, lastName, user.Id, token, role.RoleName.ToUpper(), role.Id, PropertyValues.isOTPEnabled());
                        return new Result<AuthenticateResponse>() { Data = authenticateResponse };

                    }
                    
                    if (getUserLoginHistory.IsNull())
                    {
                        _ = await _passwordPolicyService.CreateLoginHistory(user.Id, passwordPolicy.ExpireTime);
                        return new Result<AuthenticateResponse>().AddError(Error.InvalidLogin);
                    }
                    else
                    {
                        var noOfAttemptsFailed = await _passwordPolicyService.UpdateLoginHistory(getUserLoginHistory, user, passwordPolicy);
                        if(noOfAttemptsFailed == passwordPolicy.AttemptLimits) return new Result<AuthenticateResponse>().AddError(string.Format(Constants.AccountLocked, passwordPolicy.ExpireTime));
                    }
                    return new Result<AuthenticateResponse>().AddError(Error.InvalidLogin);
                }
                return new Result<AuthenticateResponse>().AddError(string.Format(Constants.AccountLocked, passwordPolicy.ExpireTime));
            }
            
            return new Result<AuthenticateResponse>().AddError(Error.InvalidLogin);
        }

        public async Task<Result<AuthenticateResponse>> LoginWithoutOTP(Authenticate authenticate)
        {
            if (await _userRepository.IsUserExists(authenticate.EmailAddress))
            {
                var user = await _userRepository.GetUserByEmailAddress(authenticate.EmailAddress);
                if (PasswordEncryptionDecryption.ValidatePassword(authenticate.Password, user.Password))
                {
                    AuthenticateResponse authenticateResponse;
                    await _userRepository.UpdateIsUsernamePasswordValidated(user, true);

                    var userHasRole = await _userHasRolesRepository.GetUserRoleByUserId(user.Id);
                    var role = await _roleRepository.FindByIdAsync(userHasRole.Role.Id.ToString(), cancellationToken: CancellationToken.None);

                    var firstName = user.FirstName;
                    var lastName = user.LastName;

                    var sessionActivity = await _sessionService.InitiateSession(user);
                    var token = await GetAccessToken(user, role.RoleName, sessionActivity.Id);
                    authenticateResponse = _userAccountMapper.MapFrom(user, firstName, lastName, user.Id, token, role.RoleName.ToUpper(), role.Id, PropertyValues.isOTPEnabled());

                    return new Result<AuthenticateResponse>() { Data = authenticateResponse };
                }
                return new Result<AuthenticateResponse>().AddError(Error.InvalidLogin);
            }
            return new Result<AuthenticateResponse>().AddError(Error.InvalidLogin);
        }

        public async Task<Result<MessageDto>> SendOTP(SendOTP sendOtp)
        {
            var user = await _userRepository.GetUserByEmailAddress(sendOtp.EmailAddress);
            if (user.IsNull()) return new Result<MessageDto>().AddError(Error.InvalidRequest);

            if (sendOtp.LoginFlag && !user.IsAuthenticated)
                return new Result<MessageDto>().AddError(Error.InvalidRequest);

            var fullName = user.FirstName + " " + user.LastName;

            var otp = await _emailService.SendOTPConfirmation(user, fullName, Application.MailTypeOTP,
                Application.OTPLoginEmailSubject);
            if (otp.isNullOrEmpty())
                return new Result<MessageDto>().AddError(Error.FailedToSendOTP);

            if (!sendOtp.LoginFlag) await _userRepository.UpdateCanChangePassword(user, true);
            var isOTPUpdated = await _userRepository.UpdateUserByOtp(user, otp);
            if (isOTPUpdated)
            {
                return new Result<MessageDto>()
                {
                    Data = new MessageDto().AddMessage(Application.OTPSuccess)
                        .AddMessage(user.EmailAddress),
                    NextAction = sendOtp.LoginFlag.ToString()
                };
            }

            return new Result<MessageDto>().AddError(Error.FailedToSaveToken);
        }

        public async Task<Result<AuthenticateResponse>> ValidateOTP(ValidateOTP validateOtp)
        {
            var user = await _userRepository.GetUserByEmailAddress(validateOtp.EmailAddress);
            if (user.IsNull() || user.OtpNumber.isNullOrEmpty()) return new Result<AuthenticateResponse>().AddError(Error.InvalidRequest);

            //Validate OTP
            if (user.OtpNumber.Equals(validateOtp.OtpNumber) && user.LoginOTPUpdatedTime.Value.AddHours(2) > DateTime.UtcNow)
            {
                await _userRepository.UpdateOtpNumberAndIsUsernamePasswordValidated(user, false);


                var userHasRole = await _userHasRolesRepository.GetUserRoleByUserId(user.Id);
                var role = await _roleRepository.FindByIdAsync(userHasRole.Role.Id.ToString(), cancellationToken: CancellationToken.None);

                var sessionActivity = await _sessionService.InitiateSession(user);
                var token = await GetAccessToken(user, role.RoleName, sessionActivity.Id);
                var authenticateResponse = _userAccountMapper.MapFrom(user, user.FirstName, user.LastName, user.Id, token, role.RoleName.ToUpper(), role.Id, PropertyValues.isOTPEnabled());

                return new Result<AuthenticateResponse>() { Data = authenticateResponse };
            }

            return new Result<AuthenticateResponse>().AddError(Error.InvalidOTP);
        }

        public Result<AuthenticateResponse> ForgotMyPassword(ForgotPassword forgotPassword)
        {
            var user = _userRepository.GetUserByEmailAddress(forgotPassword.EmailAddress).GetAwaiter()
                .GetResult();

            if (GenericTypeExtensions.IsNotNull(user))
            {
                var userAccountDto = _userAccountMapper.MapFrom(user);
                return new Result<AuthenticateResponse>() { Data = userAccountDto };
            }

            return new Result<AuthenticateResponse>().AddError(Error.UserNotFound);
        }

        public async Task<Result<MessageDto>> UpdateNewPassword(ResetPassword resetPassword)
        {
            var user = await _userRepository.GetUserByEmailAddress(resetPassword.EmailAddress);
            if (!user.IsNotNull()) return new Result<MessageDto>().AddError(Error.InvalidRequest);

            //Update new password into db

            if (!user.CanChangePassword) return new Result<MessageDto>().AddError(Error.InvalidRequest);


            var isPasswordSet = await _userRepository.UpdateUserPassword(user, resetPassword.ConfirmPassword);
            if (!isPasswordSet) return new Result<MessageDto>().AddError(Error.UpdatePasswordFailed);

            var isCanChangePasswordUpdated = await _userRepository.UpdateCanChangePassword(user, false);
            if (!isCanChangePasswordUpdated) return new Result<MessageDto>().AddError(Error.UpdateCanChangePasswordFailed);

            //Update user login history if user is InActive.
            var getUserLoginHistory = await _passwordPolicyService.GetUserLoginHistory(user.Id);
            if (getUserLoginHistory.IsNotNull())
            {
                getUserLoginHistory.NoOfAttempts = 0;
                user.IsActive = true;
                await _userRepository.Update(user);
                await _passwordPolicyRepository.UpdateLoginHistory(getUserLoginHistory);
            }
            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.UpdatePasswordSuccess) };
        }
        private async Task<string> GetAccessToken(User user, string role, long sessionId)
        {
            return _jwtHelper.GetEncryptedAccessToken(_jwtHelper.CreateAccessToken(
                _jwtHelper.CreateJwtClaims(
                    (await _claimsPrincipalFactory.CreateAsync(user))
                    .Identity as ClaimsIdentity, role, sessionId)));
        }

        public async Task<Result<MessageDto>> Logout(long userId)
        {
            var result = await _sessionActivityRepository.DeactivateTheSession(userId);
            return result ? new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.LogoutSuccess) } : new Result<MessageDto>().AddError(Error.LogoutFailure);
        }

        public async Task<Result<MessageDto>> ChangePassword(ChangePassword changePassword)
        {
            var user = await _userRepository.GetUserByEmailAddress(changePassword.EmailAddress);
            if (!user.IsNotNull()) return new Result<MessageDto>().AddError(Error.InvalidRequest);

            var isPasswordSet = await _userRepository.ChangePassword(user, changePassword.NewPassword);
            if (!isPasswordSet) return new Result<MessageDto>().AddError(Error.UpdatePasswordFailed);

            return new Result<MessageDto>()
            { Data = new MessageDto().AddMessage(Application.UpdatePasswordSuccess) };
        }
    }
}