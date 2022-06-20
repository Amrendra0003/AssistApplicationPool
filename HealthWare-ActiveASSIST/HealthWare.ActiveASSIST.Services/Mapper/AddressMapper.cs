using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Entities;
using ContactDetails = Healthware.Core.Entities.ContactDetails;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IContactDetailsMapper
    {
        ContactDetailsInfo MapFrom(HouseHoldIncomeDetails incomeDto, long assessmentId);
        ContactDetails MapFrom(ContactDetails patientContactDetails);
        ContactDetails MapFrom(ContactDetailsInfo contactDetailsDto);
        ContactDetails MapFrom(ContactDetails contactDetails, UpdateContactDetails updateContactDto);
        ContactDetails MapFrom(ContactDetails guarantorContactDetails, ContactDetails updatedContactDetails);
        ContactDetails MapFrom(ContactDetails contactDetails, HouseHoldIncomeDetails incomeDto);
    }

    public class ContactDetailsMapper : IContactDetailsMapper
    {
        //AddressInfo Mapper for HouseHoldIncome
        public ContactDetailsInfo MapFrom(HouseHoldIncomeDetails incomeDto, long assessmentId)
        {
            var contactDetailsDto = new ContactDetailsInfo()
            {
                Name = incomeDto.CompanyName,
                //TODO: Later change the address type value to dynamic
                ContactTypeId = (long)Enums.ContactType.HouseHoldIncome,
                AssessmentId = assessmentId,
                StreetAddress = incomeDto.StreetAddress,
                City = incomeDto.City,
                State = incomeDto.State,
                ZipCode = incomeDto.ZipCode,
                CellNumber = incomeDto.CellNumber,
                Fax = incomeDto.Fax,
                CountyCode = incomeDto.CountyCode,
            };
            return contactDetailsDto;
        }

        public ContactDetails MapFrom(ContactDetails patientContactDetails)
        {
            var contactDetails = new ContactDetails()
            {
                ContactTypeDetails = patientContactDetails.ContactTypeDetails,
                Name = patientContactDetails.Name,
                StreetAddress = patientContactDetails.StreetAddress,
                Suite = patientContactDetails.Suite,
                City = patientContactDetails.City,
                State = patientContactDetails.State,
                County = patientContactDetails.County,
                Zip = patientContactDetails.Zip,
                CountyCode = patientContactDetails.CountyCode,
                Cell = patientContactDetails.Cell
            };
            return contactDetails;
        }

        //Insert Address Mapper
        public ContactDetails MapFrom(ContactDetailsInfo contactDetailsDto)
        {
            var homeContactDetails = new ContactDetails()
            {
                ContactTypeDetails = new ContactTypeMaster { Id = contactDetailsDto.ContactTypeId },
                Suite = contactDetailsDto.Suite,
                City = contactDetailsDto.City,
                State = contactDetailsDto.State,
                StateCode = contactDetailsDto.StateCode,
                Zip = contactDetailsDto.ZipCode,
                County = contactDetailsDto.County,
                Cell = contactDetailsDto.CellNumber,
                CountyCode = contactDetailsDto.CountyCode,
                StreetAddress = contactDetailsDto.StreetAddress,
                Name = contactDetailsDto.Name,
                Fax = contactDetailsDto.Fax,
                Email = contactDetailsDto.Email
            };
            return homeContactDetails;
        }

        //Update Address Mapper
        public ContactDetails MapFrom(ContactDetails contactDetails, UpdateContactDetails updateContactDto)
        {
            contactDetails.Name = updateContactDto.Name;
            contactDetails.StreetAddress = updateContactDto.StreetAddress;
            contactDetails.Suite = updateContactDto.Suite;
            contactDetails.City = updateContactDto.City;
            contactDetails.State = updateContactDto.State;
            contactDetails.Zip = updateContactDto.ZipCode;
            contactDetails.County = updateContactDto.County;
            contactDetails.Cell = updateContactDto.CellNumber;
            contactDetails.CountyCode = updateContactDto.CountyCode;
            contactDetails.Fax = updateContactDto.Fax;
            contactDetails.StateCode = updateContactDto.StateCode;

            return contactDetails;
        }

        public ContactDetails MapFrom(ContactDetails guarantorContactDetails, ContactDetails updatedContactDetails)
        {
            guarantorContactDetails.Name = updatedContactDetails.Name;
            guarantorContactDetails.StreetAddress = updatedContactDetails.StreetAddress;
            guarantorContactDetails.Suite = updatedContactDetails.Suite;
            guarantorContactDetails.City = updatedContactDetails.City;
            guarantorContactDetails.State = updatedContactDetails.State;
            guarantorContactDetails.Zip = updatedContactDetails.Zip;
            guarantorContactDetails.County = updatedContactDetails.County;
            guarantorContactDetails.Cell = updatedContactDetails.Cell;
            guarantorContactDetails.CountyCode = updatedContactDetails.CountyCode;
            guarantorContactDetails.Fax = updatedContactDetails.Fax;
            return guarantorContactDetails;
        }

        //Update income address
        public ContactDetails MapFrom(ContactDetails contactDetails, HouseHoldIncomeDetails incomeDto)
        {
            contactDetails.Name = incomeDto.CompanyName;
            contactDetails.StreetAddress = incomeDto.StreetAddress;
            contactDetails.City = incomeDto.City;
            contactDetails.State = incomeDto.State;
            contactDetails.Zip = incomeDto.ZipCode;
            contactDetails.Cell = incomeDto.CellNumber;
            contactDetails.CountyCode = incomeDto.CountyCode;
            contactDetails.Fax = incomeDto.Fax;
            return contactDetails;
        }
    }
}