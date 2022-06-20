using System;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.DTOs.Authentication;
using Healthware.Core.Extensions;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IBasicInfoMapper
    {
        Entities.BasicInfo CreateMapFrom(CreateAssessment createAssessmentDto);
        Entities.BasicInfo CreateMapFrom(CreateAssessment createAssessmentDto, string firstName, string middleName,string lastName,
            DateTime dateOfBirth, string gender, string maritalStatus, string emailAddress, string cellNumber);
        PatientBasicInfo MapFrom(Entities.BasicInfo basicInfo, bool isPatientSelfGuarantor);
        Entities.BasicInfo MapFrom(Entities.BasicInfo basicInfo, PatientPersonalDetail patientPersonalDetail);
    }
    public class BasicInfoMapper : IBasicInfoMapper
    {
        public Entities.BasicInfo CreateMapFrom(CreateAssessment createAssessmentDto, string firstName, string middleName,string lastName,
            DateTime dateOfBirth, string gender, string maritalStatus, string emailAddress, string cellNumber)
        {
            var patient = new Entities.BasicInfo
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                MaritalStatus = maritalStatus,
                EmailAddress = emailAddress,
                CellNumber = cellNumber,
                CountyCode = createAssessmentDto.AssessmentContactDetails.CountyCode,
                SSNNumber = createAssessmentDto.SSN,
                ReasonNoSsn = createAssessmentDto.ReasonNoSsn
            };
            return patient;
        }

        public Entities.BasicInfo CreateMapFrom(CreateAssessment createAssessmentDto)
        {
            var patient = new Entities.BasicInfo();
            foreach (var questionAndAnswer in createAssessmentDto.QuestionAndAnswers)
            {
                switch (questionAndAnswer.QuestionId)
                {
                    case 7:
                        patient.FirstName = questionAndAnswer.Value;
                        break;
                    case 8:
                        patient.LastName = questionAndAnswer.Value;
                        break;
                    case 9:
                        patient.DateOfBirth = questionAndAnswer.Value.ConvertStringToDate();
                        break;
                    case 10:
                        patient.Gender = questionAndAnswer.Value;
                        break;
                    case 11:
                        patient.MaritalStatus = questionAndAnswer.Value;
                        break;
                    case 12:
                        patient.EmailAddress = questionAndAnswer.Value;
                        break;
                    case 13:
                        patient.CellNumber = questionAndAnswer.Value;
                        break;
                    case 38:
                        patient.MiddleName = questionAndAnswer.Value;
                        break;
                }
            }
            patient.CountyCode = Constants.OneAsString;
            patient.SSNNumber = createAssessmentDto.SSN.IsNotNullOrEmpty() ? createAssessmentDto.SSN : null;
            patient.ReasonNoSsn = createAssessmentDto.ReasonNoSsn.IsNotNullOrEmpty() ? createAssessmentDto.ReasonNoSsn : null;
            return patient;
        }
        public PatientBasicInfo MapFrom(Entities.BasicInfo basicInfo, bool isPatientSelfGuarantor)
        {
            var last = "";
            if (basicInfo.SSNNumber.IsNotNullOrEmpty())
            {
                last = basicInfo.SSNNumber.Substring(basicInfo.SSNNumber.Length - 4, 4);
            }
            
            var patientBasicInfo = new PatientBasicInfo()
            {
                FirstName = basicInfo.FirstName,
                MiddleName = basicInfo.MiddleName,
                LastName = basicInfo.LastName,
                Suffix = basicInfo.Suffix,
                MaidenName = basicInfo.MaidenName,
                DateOfBirth = basicInfo.DateOfBirth.ToInvariantDateString(),
                Gender = basicInfo.Gender,
                MaritalStatus = basicInfo.MaritalStatus,
                EmailAddress = basicInfo.EmailAddress,
                CellNumber = basicInfo.CellNumber,
                CountyCode = basicInfo.CountyCode,
                SSNNumber = basicInfo.SSNNumber.IsNotNullOrEmpty() ? string.Format(Constants.SsnMask, last) : null,
                SSNNumberUnMasked = basicInfo.SSNNumber,
                ReasonNoSsn = basicInfo.ReasonNoSsn,
                AreYouGuarantor = isPatientSelfGuarantor
            };
            return patientBasicInfo;
        }
        public Entities.BasicInfo MapFrom(Entities.BasicInfo basicInfo, PatientPersonalDetail patientPersonalDetail)
        {
            basicInfo.FirstName = patientPersonalDetail.FirstName;
            basicInfo.LastName = patientPersonalDetail.LastName;
            basicInfo.MiddleName = patientPersonalDetail.MiddleName;
            basicInfo.EmailAddress = patientPersonalDetail.EmailAddress;
            basicInfo.Suffix = patientPersonalDetail.Suffix;
            basicInfo.MaidenName = patientPersonalDetail.MaidenName;
            basicInfo.DateOfBirth = patientPersonalDetail.DateOfBirth.ConvertStringToDate();
            basicInfo.Gender = patientPersonalDetail.Gender;
            basicInfo.MaritalStatus = patientPersonalDetail.MaritalStatus;
            basicInfo.CountyCode = patientPersonalDetail.CountyCode;
            basicInfo.CellNumber = patientPersonalDetail.Cell;
            basicInfo.SSNNumber = patientPersonalDetail.SSN;
            basicInfo.ReasonNoSsn = patientPersonalDetail.ReasonNoSSN;

            return basicInfo;
        }

    }
}
