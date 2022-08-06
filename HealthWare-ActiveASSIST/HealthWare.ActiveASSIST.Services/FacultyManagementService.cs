using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.Mappings;
using HealthWare.ActiveASSIST.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IFacultyManagementService
    {
        List<FacultyEntity> ValidateCsv(List<FacultyEntity> patients);
        Task<bool> CheckIfFacultyExists(string facilityName, string facilityCode);
        Task<long> CreateFaculty(FacultyEntity faculty);
    }
    public class FacultyManagementService : IFacultyManagementService
    {
        private readonly IFacultyRepository _facultyRepository;
        public FacultyManagementService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }
        public List<FacultyEntity> ValidateCsv(List<FacultyEntity> faculties)
        {
            var faculty = new List<FacultyEntity>();
            foreach (var item in faculties)
            {
                bool isFacilityNameValid = Regex.IsMatch(item.FacilityName, @"^[a-zA-Z ]*$");
                bool isAccessGroupIDValid = Regex.IsMatch(item.AccessGroupID, @"^[0-9]+$");
                if (isFacilityNameValid && isAccessGroupIDValid)
                {
                    var newFaculty1 = new FacultyEntity();
                    newFaculty1 = item;
                    faculty.Add(newFaculty1);
                }
            }
            return faculty;
        }
        public async Task<bool> CheckIfFacultyExists(string facilityName, string facilityCode)
        {
            var isPatientExists = await _facultyRepository.IsFacultyExists(facilityName, facilityCode);
            return isPatientExists;
        }
        public async Task<long> CreateFaculty(FacultyEntity faculties)
        {
            Facilities faculty = new Facilities()
            {
                FacilityName = faculties.FacilityName,      
                FacilityCode = faculties.FacilityCode,
                AccessGroupID = faculties.AccessGroupID,
                IsDeleted = true
            };
            var facultyId = await _facultyRepository.CreateFaculty(faculty);
            string[] subs = faculties.UserIds.Split(',');
            foreach (string sub in subs)
            {
                FacilityMapping fac = new FacilityMapping()
                {
                    UserId = Convert.ToInt64(sub),
                    FacilityCode = faculties.FacilityCode,
                    FacilityId = facultyId
                };
                await _facultyRepository.CreateFacilityMapping(fac);
            }
            return facultyId;
        }
    }
}
