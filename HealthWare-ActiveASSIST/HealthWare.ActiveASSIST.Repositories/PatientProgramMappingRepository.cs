using Healthware.Core.Base;
using Healthware.Core.Extensions;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IPatientProgramMappingRepository
    {
        Task<long> CreateProgramMapping(PatientProgramMapping patientProgramMapping);
        Task<IEnumerable<PatientProgramMapping>> GetAllReviewProgramsOfAssessment(long assessmentId);
        Task<IEnumerable<PatientProgramMapping>> GetNotEvaluatedActiveReviewPrograms(long assessmentId);
        Task<IEnumerable<PatientProgramMapping>> GetNotEvaluatedPrograms(long assessmentId);
        Task<IEnumerable<PatientProgramMapping>> GetEvaluatedPrograms(long assessmentId);
        Task<IEnumerable<PatientProgramMapping>> GetActiveReviewPrograms(long assessmentId);
        Task<bool> UpdateReviewProgramStatus(long programId, long assessmentId, string status);
        Task<bool> UpdateReviewProgramStatus(PatientProgramMapping patientProgram);
        int GetProgramDocumentCount(long assessmentId);
        Task<bool> IsProgramSubmitted(long assessmentId);
        Task<PatientProgramMapping> GetEvaluatedGetMapping(long assessmentId, long id);
        Task<bool> UpdatePatientProgram(PatientProgramMapping isPatientProgramExists);
        Task<bool> DeleteProgramMapping(PatientProgramMapping programMapping);
        Task<bool> IsProgramMappingHasEvaluatedRecord(long assessmentId);
        Task<IEnumerable<PatientProgramMapping>> GetPatientProgramMappingOfActiveAndEvaluatedPrograms(long assessmentId);
    }
    public class PatientProgramMappingRepository : IPatientProgramMappingRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        public PatientProgramMappingRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> CreateProgramMapping(PatientProgramMapping patientProgramMapping)
        {
            _unitOfWork.Attach(patientProgramMapping.Assessment);
            _unitOfWork.Attach(patientProgramMapping.Program);
            await _unitOfWork.AddAsync(patientProgramMapping);
            await _unitOfWork.CommitAsync();
            return patientProgramMapping.Id;
        }
        public async Task<IEnumerable<PatientProgramMapping>> GetAllReviewProgramsOfAssessment(long assessmentId)
        {
            var programMappings = await _unitOfWork.GetAllAsync<PatientProgramMapping>(y =>y.Assessment.Id == assessmentId);
            return programMappings;
        }
        public async Task<IEnumerable<PatientProgramMapping>> GetNotEvaluatedActiveReviewPrograms(long assessmentId)
        {
            var programMappings = await _unitOfWork.GetAllAsync<PatientProgramMapping>(y => y.Assessment.Id == assessmentId && y.IsActive.Equals(true)&& y.IsEvaluated.Equals(false));
            return programMappings;
        }
        public async Task<IEnumerable<PatientProgramMapping>> GetNotEvaluatedPrograms(long assessmentId)
        {
            var programMappings = await _unitOfWork.GetAllAsync<PatientProgramMapping>(y => y.Assessment.Id == assessmentId && y.IsEvaluated.Equals(false));
            return programMappings;
        }
        public async Task<IEnumerable<PatientProgramMapping>> GetEvaluatedPrograms(long assessmentId)
        {
            var programMappings = await _unitOfWork.GetAllAsync<PatientProgramMapping>(y => y.Assessment.Id == assessmentId && y.IsEvaluated.Equals(true));
            return programMappings;
        }
        public async Task<IEnumerable<PatientProgramMapping>> GetActiveReviewPrograms(long assessmentId)
        {
            var activePatientProgramMappings = await _unitOfWork.GetAllAsync<PatientProgramMapping>(y =>y.Assessment.Id == assessmentId && y.IsActive == true && y.IsEvaluated.Equals(true));
            return activePatientProgramMappings;
        }

        public async Task<bool> UpdateReviewProgramStatus(PatientProgramMapping patientProgram)
        {
            _unitOfWork.Update(patientProgram);
            var result = await _unitOfWork.CommitAsync();
            return result;
        }

        public int GetProgramDocumentCount(long assessmentId)
        {
            var programDocumentCount = (from a in _unitOfWork.GetEntities<ProgramDocument>()
                join b in _unitOfWork.GetEntities<PatientProgramMapping>() on a.Program.Id equals b.Program.Id
                where b.Assessment.Id == assessmentId && b.IsActive.Equals(true) && b.IsEvaluated.Equals(true)
             select new PatientProgramMapping()
             {

             }).Count();
            return programDocumentCount;
        }

        public async Task<bool> UpdateReviewProgramStatus(long programId, long assessmentId, string status)
        {
            var patientProgramMapping = await _unitOfWork.GetEntityAsync<PatientProgramMapping>(x => x.Program.Id == programId && x.Assessment.Id == assessmentId && x.IsEvaluated.Equals(true));
            patientProgramMapping.Status = status;
            _unitOfWork.Update(patientProgramMapping);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsProgramSubmitted(long assessmentId)
        {
            var patientProgramMapping = await _unitOfWork.GetAllAsync<PatientProgramMapping>(a => a.Assessment.Id == assessmentId && a.Status == "Application Submitted");
            if (patientProgramMapping.Count() > 0) return true;
            return false;
        }
        public async Task<PatientProgramMapping> GetEvaluatedGetMapping(long assessmentId, long id)
        {
            var patientProgramMapping = await _unitOfWork.GetEntityAsync<Entities.PatientProgramMapping>(a => a.Assessment.Id == assessmentId && a.Program.Id == id && a.IsEvaluated.Equals(true));
            return patientProgramMapping;
        }
        public async Task<bool> UpdatePatientProgram(PatientProgramMapping isPatientProgramExists)
        {
            _unitOfWork.Update(isPatientProgramExists);
            var result = await _unitOfWork.CommitAsync();
            return result;
        }
        public async Task<bool> DeleteProgramMapping(PatientProgramMapping programMapping)
        {
            _unitOfWork.Remove(programMapping);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsProgramMappingHasEvaluatedRecord(long assessmentId)
        {
            var programMappings = await _unitOfWork.GetEntityAsync<PatientProgramMapping>(a =>
                a.Assessment.Id == assessmentId && a.IsEvaluated.Equals(true));
            if (programMappings.IsNotNull())
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<PatientProgramMapping>> GetPatientProgramMappingOfActiveAndEvaluatedPrograms(long assessmentId)
        {
            var patientProgramMappings = await _unitOfWork.GetAllAsync<PatientProgramMapping>(a =>
                a.Assessment.Id == assessmentId && a.IsActive.Equals(true) && a.IsEvaluated.Equals(true));
            return patientProgramMappings;
        }
    }
}
