using Healthware.Core.Configurations;
using Healthware.Core.Constants;
using Healthware.Core.DTO;
using Healthware.Core.Extensions;
using Healthware.Core.Security;
using Healthware.Core.Utility;
using Healthware.Core.Web.Web.Common.SMS;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using HealthWare.ActiveASSIST.Repositories;
using HealthWare.ActiveASSIST.Web.Common.Email;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IVerificationService
    {
        Task<Result<AssessmentVerificationResponse>> GetEmailVerificationStatus(BasePatientAssessment basePatientAssessment);
        Task<Result<MessageDto>> SendEmailVerification(BasePatientAssessment basePatientAssessment);
        Task<Result<TokenValidation>> ValidateEmailConfirmationToken(string token);
        Task<Result<MessageDto>> SendOtpToCell(CellConfirmationOTPModel otpModel);
        Task<Result<MessageDto>> ValidateCellVerificationOtp(ValidateOTP otpModel);
        Task<Result<Dictionary<string, string>>> GetHouseHoldMemberNames(BasePatientAssessment patientAssessment);
    }
    public class VerificationService: IVerificationService
    {
        private readonly IBasicInfoRepository _basicInfoRepository;
        private readonly IAssessmentVerificationRepository _assessmentVerificationRepository;
        private readonly IEmailService _emailService;
        private readonly IAssessmentService _assessmentService;
        private readonly IHouseHoldMemberRepository _houseHoldMemberRepository;
        private readonly ISMSService _smsService;

        public VerificationService(IBasicInfoRepository basicInfoRepository, IAssessmentVerificationRepository assessmentVerificationRepository, IEmailService emailService, IAssessmentService assessmentService, IHouseHoldMemberRepository houseHoldMemberRepository, ISMSService smsService)
        {
            _basicInfoRepository = basicInfoRepository;
            _assessmentVerificationRepository = assessmentVerificationRepository;
            _emailService = emailService;
            _assessmentService = assessmentService;
            _houseHoldMemberRepository = houseHoldMemberRepository;
            _smsService = smsService;
        }
        public async Task<Result<AssessmentVerificationResponse>> GetEmailVerificationStatus(BasePatientAssessment basePatientAssessment)
        {

            var verification =
                await _assessmentVerificationRepository.GetVerification(basePatientAssessment.AssessmentId);

            var basicInfo = await _basicInfoRepository.GetBasicInfoByAssessment(verification.Assessment.Id);
            if (basicInfo.IsNull()) return new Result<AssessmentVerificationResponse>().AddError(Error.PatientNotFound);

            var verificationResponseDto = new AssessmentVerificationResponse
            {
                IsEmailConfirmed = verification.IsEmailConfirmed,
                IsCellConfirmed = verification.IsCellNumberConfirmed,
                CountyCode = basicInfo.CountyCode,
                CellNumber = basicInfo.CellNumber
            };

            return new Result<AssessmentVerificationResponse>()
                { Data = verificationResponseDto };
        }
        public async Task<Result<MessageDto>> SendEmailVerification(BasePatientAssessment basePatientAssessment)
        {
            var basicInfo = await _basicInfoRepository.GetBasicInfoById(basePatientAssessment.PatientId);
            if (basicInfo.IsNull()) return new Result<MessageDto>().AddError(Error.PatientNotFound);

            var verification = await _assessmentVerificationRepository.GetVerification(basePatientAssessment.AssessmentId);

            if (verification.IsNotNull())
            {
                if (verification.IsEmailConfirmed) return new Result<MessageDto>().AddError(Error.EmailVerified);
                PropertyValues.ByePassVerification("false");
                if (PropertyValues.IsVerificationByePassed())
                {
                    if (!verification.IsEmailConfirmed)
                    {
                        await _assessmentVerificationRepository.UpdateVerificationByEmailConfirmed(verification, true);
                        //Update tab status
                        await _assessmentService.UpdateTabStatus(basePatientAssessment.AssessmentId, Constants.EmailVerification, true);
                        return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.VerificationEmailSent) };
                    }
                }
                else
                {
                    var mailType = Application.MailTypeEmailConfirmation;
                    var mailSubject = Application.EmailConfirmSubject;
                    var token = await _emailService.SendEmailConfirmation(basicInfo, basePatientAssessment.AssessmentId, mailType, mailSubject);
                    if (!string.IsNullOrEmpty(token))
                    {
                        var isTokenUpdated = await _assessmentVerificationRepository.UpdateVerificationByToken(verification, token);
                        if (isTokenUpdated) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.VerificationEmailSent) };
                        return new Result<MessageDto>().AddError(Error.UpdateAssessmentVerificationFailed);
                    }
                }
                
            }
            return new Result<MessageDto>().AddError(Error.AssessmentVerificationNotFound);
        }

        public async Task<Result<TokenValidation>> ValidateEmailConfirmationToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return new Result<TokenValidation>().AddError(Error.InvalidToken);

            var handler = new JwtSecurityTokenHandler();
            var tokenValues = handler.ReadToken(token) as JwtSecurityToken;
            var patientId = tokenValues.Claims.First(claim => claim.Type == Application.ClaimsPatientId).Value;

            var basicInfo = await _basicInfoRepository.GetBasicInfoById(Convert.ToInt64(patientId));

            var assessmentId = Convert.ToInt64(tokenValues.Claims.First(claim => claim.Type == Application.ClaimsAssessmentId).Value);
            var verification = await _assessmentVerificationRepository.GetVerification(assessmentId);

            if (!verification.EmailVerificationToken.Equals(token))
                return new Result<TokenValidation>().AddError(Error.InvalidToken);
            var tokenLifeTime = new JwtSecurityTokenHandler().ReadToken(token).ValidTo.ToString();
            DateTime tokenValidTime = DateTime.Parse(tokenLifeTime);
            if (Clock.Now() > tokenValidTime)
            {
                return new Result<TokenValidation>().AddError(Error.TokenExpired);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.HealthWareKey);

            try
            {
                var userClaims = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                },
                    out SecurityToken validatedToken);
                if (userClaims != null)
                {
                    var jwtToken = (JwtSecurityToken)validatedToken;

                    string mailType = jwtToken.Claims.FirstOrDefault(x => x.Type == UserClaimTypes.MailType).Value
                        .ToString();

                    if (!verification.IsEmailConfirmed)
                    {
                        await _assessmentVerificationRepository.UpdateVerificationByEmailConfirmed(verification, true);
                        var tokenValidationDto = new TokenValidation()
                        {
                            EmailAddress = basicInfo.EmailAddress,
                            PatientName = basicInfo.FirstName + Healthware.Core.Extensions.StringExtensions.Space + basicInfo.LastName
                        };

                        //Update tab status
                        await _assessmentService.UpdateTabStatus(assessmentId, Constants.EmailVerification, true);

                        return new Result<TokenValidation>()
                        { Data = tokenValidationDto, NextAction = mailType };
                    }

                    return new Result<TokenValidation>().AddError(Constants.EmailConfirmationAlreadyDone);
                }
            }
            catch (Exception)
            {
                return new Result<TokenValidation>().AddError(Error.InvalidToken);
            }

            return new Result<TokenValidation>().AddError(Error.InvalidToken);
        }
       
        public async Task<Result<MessageDto>> SendOtpToCell(CellConfirmationOTPModel otpModel)
        {
            var verification = await _assessmentVerificationRepository.GetVerification(otpModel.AssessmentId);
            if (verification.IsCellNumberConfirmed) return new Result<MessageDto>().AddError(Error.CellNumberVerified);

            var otp = _smsService.GetOTP();
            //TODO: Need to integrate SMS

            if (true)
            {
                var isOtpUpdated = await _assessmentVerificationRepository.UpdateVerificationByCellNumberOtp(verification, otp);
                if (isOtpUpdated) return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.OTPSuccess) };
            }
            return new Result<MessageDto>().AddError(Error.FailedToSendOTP);
        }
        public async Task<Result<MessageDto>> ValidateCellVerificationOtp(ValidateOTP otpModel)
        {
            var verification = await _assessmentVerificationRepository.GetVerification(otpModel.AssessmentId);

            if (verification.CellNumberOTP.IsNotNull())
            {
                PropertyValues.ByePassVerification("true");
                if (PropertyValues.IsVerificationByePassed())
                {
                    var isCellNumberConfirmed = await _assessmentVerificationRepository.UpdateVerificationByCellNumberConfirmed(verification, true);
                    if (isCellNumberConfirmed)
                    {
                        //Update tab status
                        await _assessmentService.UpdateTabStatus(verification.Assessment.Id, Constants.CellVerification, true);

                        return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.OTPValidationSuccess) };
                    }
                    return new Result<MessageDto>().AddError(Error.UpdateCellNumberFailed);
                }
                else
                {
                    if (verification.CellNumberOTPUpdatedTime.Value.AddMinutes(10) > DateTime.UtcNow && verification.CellNumberOTP.Equals(otpModel.OtpNumber))
                    {
                        var isCellNumberConfirmed = await _assessmentVerificationRepository.UpdateVerificationByCellNumberConfirmed(verification, true);
                        if (isCellNumberConfirmed)
                        {
                            //Update tab status
                            await _assessmentService.UpdateTabStatus(verification.Assessment.Id, Constants.CellVerification, true);

                            return new Result<MessageDto>() { Data = new MessageDto().AddMessage(Application.OTPValidationSuccess) };
                        }
                        return new Result<MessageDto>().AddError(Error.UpdateCellNumberFailed);
                    }
                    return new Result<MessageDto>().AddError(Error.InvalidOTP);
                }
                
            }
            return new Result<MessageDto>().AddError(Error.InvalidRequest);
        }
        public async Task<Result<Dictionary<string, string>>> GetHouseHoldMemberNames(BasePatientAssessment patientAssessment)
        {
            var houseHoldMembers = await _houseHoldMemberRepository.
                GetHouseHoldNames(patientAssessment.AssessmentId);

            if (houseHoldMembers.Count().Equals(0)) return new Result<Dictionary<string, string>>() { Data = null };

            var houseHoldMemberNamesDictionary = houseHoldMembers.ToDictionary(x => x.Id.ToString(), y => y.FirstName + Healthware.Core.Extensions.StringExtensions.Space + y.LastName);
            return new Result<Dictionary<string, string>>() { Data = houseHoldMemberNamesDictionary };
        }
    }
}
