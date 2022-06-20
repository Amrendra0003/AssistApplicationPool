using System.Globalization;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Extensions;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IGuarantorMapper
    {
        Guarantor MapFrom(CreateGuarantorRequest createGuarantorRequest);
        Guarantor MapFrom(BasicInfo basicInfo, long assessmentId);
        Guarantor MapFrom(Guarantor guarantor, BasicInfo basicInfo);
        GetGuarantorResponse MapFrom(Guarantor guarantor);
        Guarantor MapFrom(GuarantorInfo guarantorInfo, long assessmentId);
    }

    public class GuarantorMapper : IGuarantorMapper
    {
        //Create Guarantor mapper
        public Guarantor MapFrom(CreateGuarantorRequest createGuarantorRequest)
        {
            var guarantor = new Guarantor()
            {
                Assessment = new Entities.Assessment { Id = createGuarantorRequest.AssessmentId },
                RelationShipWithPatient = createGuarantorRequest.RelationshipWithPatient,
                FirstName = createGuarantorRequest.FirstName,
                MiddleName = createGuarantorRequest.MiddleName,
                LastName = createGuarantorRequest.LastName,
                Suffix = createGuarantorRequest.Suffix,
                DateOfBirth = createGuarantorRequest.DateOfBirth.ConvertStringToDate(),
                EmailAddress = createGuarantorRequest.EmailAddress,
                Cell = createGuarantorRequest.Cell,
                CountyCode = createGuarantorRequest.CountyCode,
                SSNNumber = createGuarantorRequest.SSNNumber,
                ReasonNoSsn = createGuarantorRequest.ReasonNoSsn
            };
            return guarantor;
        }

        //Create Guarantor mapper via UpdatePersonalDetail API
        public Guarantor MapFrom(BasicInfo basicInfo, long assessmentId)
        {
            var guarantor = new Guarantor()
            {
                Assessment = new Assessment { Id = assessmentId },
                RelationShipWithPatient = Constants.Self,
                FirstName = basicInfo.FirstName,
                MiddleName = basicInfo.MiddleName,
                LastName = basicInfo.LastName,
                Suffix = basicInfo.Suffix,
                DateOfBirth = basicInfo.DateOfBirth,
                EmailAddress = basicInfo.EmailAddress,
                Cell = basicInfo.CellNumber,
                CountyCode = basicInfo.CountyCode,
                SSNNumber = basicInfo.SSNNumber,
                ReasonNoSsn = basicInfo.ReasonNoSsn
            };
            return guarantor;
        }

        //Mapper for update Guarantor with SELF relationship
        public Guarantor MapFrom(Guarantor guarantor, BasicInfo basicInfo)
        {
            guarantor.RelationShipWithPatient = Constants.Self;
            guarantor.FirstName = basicInfo.FirstName;
            guarantor.MiddleName = basicInfo.MiddleName;
            guarantor.LastName = basicInfo.LastName;
            guarantor.Suffix = basicInfo.Suffix;
            guarantor.DateOfBirth = basicInfo.DateOfBirth;
            guarantor.EmailAddress = basicInfo.EmailAddress;
            guarantor.Cell = basicInfo.CellNumber;
            guarantor.CountyCode = basicInfo.CountyCode;
            guarantor.SSNNumber = basicInfo.SSNNumber;
            guarantor.ReasonNoSsn = basicInfo.ReasonNoSsn;
            return guarantor;
        }

        public GetGuarantorResponse MapFrom(Guarantor guarantor)
        {
            var getGuarantorResponse = new GetGuarantorResponse
            {
                Id = guarantor.Id,
                AssessmentId = guarantor.Assessment.Id,
                RelationShipWithPatient = guarantor.RelationShipWithPatient,
                FirstName = guarantor.FirstName,
                MiddleName = guarantor.MiddleName,
                LastName = guarantor.LastName,
                Suffix = guarantor.Suffix,
                EmailAddress = guarantor.EmailAddress,
                Cell = guarantor.Cell,
                CountyCode = guarantor.CountyCode,
                SSNNumber = guarantor.SSNNumber,
                ReasonNoSsn = guarantor.ReasonNoSsn,
                DateOfBirth = guarantor.DateOfBirth.HasValue ? guarantor.DateOfBirth.Value.ToString(Constants.MonthDayYear, CultureInfo.InvariantCulture) : null
            };
            return getGuarantorResponse;
        }

        public Guarantor MapFrom(GuarantorInfo guarantorInfo, long assessmentId)
        {
            var guarantor = new Guarantor
            {
                Assessment = new Assessment { Id = assessmentId },
                RelationShipWithPatient = guarantorInfo.RelationshipWithPatient,
                FirstName = guarantorInfo.FirstName,
                MiddleName = guarantorInfo.MiddleName,
                LastName = guarantorInfo.LastName,
                Suffix = null,
                EmailAddress = guarantorInfo.Email,
                Cell = guarantorInfo.CellNumber,
                CountyCode = guarantorInfo.CountyCode,
                SSNNumber = null,
                DateOfBirth = null
            };
            return guarantor;
        }
    }
}