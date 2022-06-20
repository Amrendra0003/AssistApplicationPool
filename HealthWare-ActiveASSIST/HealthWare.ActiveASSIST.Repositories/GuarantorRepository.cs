using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IGuarantorRepository
    {
        Task<long> CreateGuarantor(Entities.Guarantor guarantor);
        Task<Entities.Guarantor> GetGuarantorById(long guarantorId);
        Task<bool> UpdateGuarantor(Entities.Guarantor updatedGuarantor);
        Task<Entities.Guarantor> GetGuarantorByAssessmentId(long assessmentId);
        Task<bool> DeleteGuarantor(Entities.Guarantor isGuarantorExists);
        Task<bool> IsPatientSelfGuarantor(long assessmentId, string relationShipWithPatient);
    }

    public class GuarantorRepository : IGuarantorRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public GuarantorRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateGuarantor(Entities.Guarantor guarantor)
        {
            _unitOfWork.Attach(guarantor.Assessment);
            await _unitOfWork.AddAsync(guarantor);
            await _unitOfWork.CommitAsync();
            return guarantor.Id;
        }

        public async Task<Entities.Guarantor> GetGuarantorById(long guarantorId)
        {
            var guarantor = await _unitOfWork.GetEntityAsync<Entities.Guarantor>(y => y.Id == guarantorId);
            return guarantor;
        }

        public async Task<bool> UpdateGuarantor(Entities.Guarantor updatedGuarantor)
        {
            _unitOfWork.Update(updatedGuarantor);
            var doesGuarantorUpdated = await _unitOfWork.CommitAsync();
            return doesGuarantorUpdated;
        }

        public async Task<Entities.Guarantor> GetGuarantorByAssessmentId(long assessmentId)
        {
            var guarantor = await _unitOfWork.GetEntityAsync<Entities.Guarantor>(y => y.Assessment.Id == assessmentId);
            return guarantor;

        }

        public async Task<bool> DeleteGuarantor(Entities.Guarantor isGuarantorExists)
        {
            _unitOfWork.Remove(isGuarantorExists);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> IsPatientSelfGuarantor(long assessmentId, string relationShipWithPatient)
        {
            var guarantorList = await _unitOfWork.GetAllAsync<Entities.Guarantor>(y => y.Assessment.Id == assessmentId && y.RelationShipWithPatient == relationShipWithPatient);
            return guarantorList.Count() > 0;
        }
    }
}