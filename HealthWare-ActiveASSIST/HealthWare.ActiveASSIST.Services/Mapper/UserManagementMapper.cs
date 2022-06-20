using System.Globalization;
using HealthWare.ActiveASSIST.DTOs;
using Healthware.Core.MultiTenancy.Entities;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IUserManagementMapper
    {
        PersonalDetail MapFrom(User user);
    }
    public class UserManagementMapper: IUserManagementMapper
    {
        public PersonalDetail MapFrom(User user)
        {
            var personalDetail = new PersonalDetail
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                DateOfBirth = user.DateOfBirth.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                Gender = user.Gender,
                Email = user.EmailAddress,
                Cell = user.Cell,
                CountyCode = user.CountyCode,
                StreetAddress = user.ContactDetails?.StreetAddress,
                Suite = user.ContactDetails?.Suite,
                City = user.ContactDetails?.City,
                State = user.ContactDetails?.State,
                County = user.ContactDetails?.County,
                ZipCode = user.ContactDetails?.Zip,
                MailingAddressCountyCode = user.ContactDetails?.CountyCode,
                MailingAddressCell = user.ContactDetails?.Cell
            };
            return personalDetail;
        }
    }
}
