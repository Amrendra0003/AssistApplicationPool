using System.Linq;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using Healthware.Core.Extensions;
using ContactDetails = HealthWare.ActiveASSIST.DTOs.ContactDetails;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IDashboardMapper
    {
        DashboardDetailResponse MapFrom(AssessmentInPatientDashboard patientDashboard);
    }
    public class DashboardMapper : IDashboardMapper
    {
        public DashboardDetailResponse MapFrom(AssessmentInPatientDashboard patientDashboard)
        {
            DashboardDetailResponse dashboardDetailResponse = new DashboardDetailResponse
            {
                FullName = patientDashboard.FullName,
                Gender = patientDashboard.Gender,
                Age = patientDashboard.Age,
                AssessmentId = patientDashboard.AssessmentId,
                AssessmentStatus = patientDashboard.AssessmentStatus,
                IsEditable = patientDashboard.IsEditable,
                StatusDisplayName = patientDashboard.StatusDisplayName,
                Programs = new Programs()
                {
                    ProgramName = patientDashboard.Programs.Split(StringExtensions.Comma).ToList()
                },
                PatientId = patientDashboard.PatientId,
                ProfileImageData = patientDashboard.ProfileImageData,
                SubmittedBy = new SubmittedBy()
                {
                    Name = patientDashboard.SubmittedByName,
                    SubmittedOn = patientDashboard.SubmittedOn,
                    CreatedDate = patientDashboard.CreatedDate,
                    HospitalName = patientDashboard.HospitalName,
                    City = patientDashboard.City
                },
                ContactDetails = new ContactDetails()
                {
                    CellNumber = $"({patientDashboard.CellNumber.Substring(0, 3)}) {patientDashboard.CellNumber.Substring(3, 3)}-{patientDashboard.CellNumber.Substring(6)}",
                    CountryCode = patientDashboard.CountryCode,
                    EmailAddress = patientDashboard.EmailAddress,
                    City = patientDashboard.City,
                    State = patientDashboard.State,
                    HomeCountryCode = patientDashboard.CountyCode,
                    HomeCellNumber = !patientDashboard.Cell.IsNullOrWhiteSpace() ? $"({patientDashboard.Cell?.Substring(0, 3)}) {patientDashboard.Cell?.Substring(3, 3)}-{patientDashboard.Cell?.Substring(6)}" : string.Empty
                }
            };
            return dashboardDetailResponse;
        }
    }
}
