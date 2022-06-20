using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;
using Healthware.Core.Extensions;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IHouseholdMemberDocumentMappingRepository
    {
       Task<long> CreateHouseholdMemberDocumentMapping(Entities.HouseholdMemberDocument householdMemberDocument);
       Task<bool> DeleteDocumentMapping(long documentId, long householdMemberId);
       Task<IEnumerable<Entities.HouseholdMemberDocument>> GetDocumentMapping(long householdMemberId);
    }
    public class HouseholdMemberDocumentMappingRepository: IHouseholdMemberDocumentMappingRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public HouseholdMemberDocumentMappingRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> CreateHouseholdMemberDocumentMapping(Entities.HouseholdMemberDocument householdMemberDocument)
        {
            _unitOfWork.Attach(householdMemberDocument.HouseholdMember);
            _unitOfWork.Attach(householdMemberDocument.Document);
            await _unitOfWork.AddAsync(householdMemberDocument);
            await _unitOfWork.CommitAsync();
            return householdMemberDocument.Id;
        }

        public async Task<bool> DeleteDocumentMapping(long documentId, long householdMemberId)
        {
            var householdMemberDocument = await _unitOfWork.GetEntityAsync<Entities.HouseholdMemberDocument>(x =>
                x.HouseholdMember.Id == householdMemberId && x.Document.Id == documentId);
            if (householdMemberDocument.IsNull()) return false;
            householdMemberDocument.HouseholdMember.Assessment = null;
            _unitOfWork.Remove(householdMemberDocument);
           return await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Entities.HouseholdMemberDocument>> GetDocumentMapping(long householdMemberId)
        {
            var householdMemberDocuments =
                await _unitOfWork.GetAllAsync<Entities.HouseholdMemberDocument>(x =>
                    x.HouseholdMember.Id == householdMemberId);
            return householdMemberDocuments;
        }
    }
}
