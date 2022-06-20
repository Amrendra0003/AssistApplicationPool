using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IContactPreferenceRepository
    {
        Task<long> CreateContactPreference(Entities.ContactPreference contactPreference);
        Task<Entities.ContactPreference> GetContactPreferenceByAssessmentId(long assessmentId);
        Task<Entities.ContactPreference> GetContactPreferenceById(long contactPreferenceId);
        Task<bool> UpdateContactPreference(Entities.ContactPreference updatedContactPreference);
    }
    public class ContactPreferenceRepository : IContactPreferenceRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public ContactPreferenceRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> CreateContactPreference(Entities.ContactPreference contactPreference)
        {
            await _unitOfWork.AddAsync(contactPreference);
            await _unitOfWork.CommitAsync();
            return contactPreference.Id;
        }

        public async Task<Entities.ContactPreference> GetContactPreferenceByAssessmentId(long assessmentId)
        {
            var contactPreference = await _unitOfWork.GetEntityAsync<Entities.ContactPreference>(y => y.AssessmentId == assessmentId);
            return contactPreference;
        }

        public async Task<Entities.ContactPreference> GetContactPreferenceById(long contactPreferenceId)
        {
            var contactPreference =
            await _unitOfWork.GetEntityAsync<Entities.ContactPreference>(y => y.Id == contactPreferenceId);
            return contactPreference;
        }

        public async Task<bool> UpdateContactPreference(Entities.ContactPreference updatedContactPreference)
        {
            _unitOfWork.Update(updatedContactPreference);
            var isContactPreferenceUpdated = await _unitOfWork.CommitAsync();
            return isContactPreferenceUpdated;
        }
    }
}
