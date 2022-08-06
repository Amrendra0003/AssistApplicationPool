using Healthware.Core.Base;
using Healthware.Core.Extensions;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.Mappings;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IFacultyRepository
    {
        Task<bool> IsFacultyExists(string facilityName, string facilityCode);
        Task<long> CreateFaculty(Entities.Facilities patient);
        Task<long> CreateFacilityMapping(FacilityMapping patient);
    }
    public class FacultyRepository : IFacultyRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public FacultyRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> IsFacultyExists(string facilityName, string facilityCode)
        {
            var facility = await _unitOfWork.GetEntityAsync<Facilities>(a => a.FacilityName == facilityName && a.FacilityCode == facilityCode);
            if (facility.IsNotNull())
            {
                return true;
            }

            return false;
        }
        public async Task<long> CreateFaculty(Entities.Facilities faculty)
        {
            await _unitOfWork.AddAsync(faculty);
            await _unitOfWork.CommitAsync();
            return faculty.Id;
        }
        public async Task<long> CreateFacilityMapping(FacilityMapping faculty)
        {
            await _unitOfWork.AddAsync(faculty);
            await _unitOfWork.CommitAsync();
            return faculty.Id;
        }
    }
}
