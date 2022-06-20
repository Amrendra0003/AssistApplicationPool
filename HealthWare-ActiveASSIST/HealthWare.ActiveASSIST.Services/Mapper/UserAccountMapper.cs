using HealthWare.ActiveASSIST.DTOs.Authentication;
using Healthware.Core.MultiTenancy.Entities;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IUserAccountMapper
    {
        AuthenticateResponse MapFrom(User user);
        AuthenticateResponse MapFrom(User user, string signedInUserFirstName, string signedInUserLastName,
            long signedInId, string token, string roleName, long roleId, bool isOtpEnabled);
    }

    public class UserAccountMapper : IUserAccountMapper
    {
        public AuthenticateResponse MapFrom(User user)
        {
            var areaCode = user.Cell.Substring(0, 3);
            var exchangeCode = user.Cell.Substring(3, 3);
            var subscriberNumber = user.Cell.Substring(6);
            var formattedContactNumber = string.Format("({0}) {1}-{2}", areaCode, exchangeCode, subscriberNumber);
            var authenticateResponse = new AuthenticateResponse()
            {
                EmailAddress = user.EmailAddress,
                ContactNumber = formattedContactNumber,
                CountryCode = user.CountyCode,
                IsOTPEnabled = true,
            };
            return authenticateResponse;
        }

        public AuthenticateResponse MapFrom(User user, string signedInUserFirstName, string signedInUserLastName,
            long signedInId, string token, string roleName, long roleId, bool isOtpEnabled)
        {
            var userAccountDto = new AuthenticateResponse()
            {
                Token = token,
                EmailAddress = user.EmailAddress,
                ContactNumber = user.Cell,
                CountryCode = user.CountyCode,
                SignedInFirstName = signedInUserFirstName,
                SignedInLastName = signedInUserLastName,
                PatientId = signedInId,
                UserId = user.Id,
                RoleId = roleId,
                Role = roleName,
                IsOTPEnabled = isOtpEnabled
            };
            return userAccountDto;
        }
    }
}