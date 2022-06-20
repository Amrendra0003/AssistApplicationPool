using Healthware.Core.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Healthware.Core.Entities;
using Healthware.Core.Enumerators;
using Healthware.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Healthware.Core.Repository
{
    public interface IContactDetailsRepository<TK> where TK : DbContext
    {
        Task<long> CreateContactDetail(ContactDetails contactDetails);
        Task<ContactDetails> GetContactDetailsById(long contactDetailsId);
        Task<bool> UpdateContactDetails(ContactDetails updatedContactDetails);
        Task<bool> DeleteContactDetails(ContactDetails contactDetails);
        Task<bool> IsPreferredCellIsGuarantor(long contactPhoneId, CoreEnums.ContactType guarantorBasic);
        Task<IEnumerable<ContactDetails>> GetContactDetailsByIds(List<long> contactDetailsIds);

    }

    public class ContactDetailsRepository<TK> : IContactDetailsRepository<TK> where TK : DbContext
    {
        private readonly IUnitOfWork<TK> _unitOfWork;

        public ContactDetailsRepository(IUnitOfWork<TK> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> CreateContactDetail(ContactDetails contactDetails)
        {
            _unitOfWork.Attach(contactDetails.ContactTypeDetails);
            await _unitOfWork.AddAsync(contactDetails);
            await _unitOfWork.CommitAsync();
            return contactDetails.Id;
        }

        public async Task<ContactDetails> GetContactDetailsById(long contactDetailsId)
        {
            var contactDetails = await _unitOfWork.GetEntityAsync<ContactDetails>(z => z.Id == contactDetailsId);
            return contactDetails;
        }

        public async Task<bool> UpdateContactDetails(ContactDetails updatedContactDetails)
        {
            _unitOfWork.Update(updatedContactDetails);
            var isContactDetailsUpdated = await _unitOfWork.CommitAsync();
            return isContactDetailsUpdated;
        }
        public async Task<bool> DeleteContactDetails(ContactDetails contactDetails)
        {
            _unitOfWork.Remove(contactDetails);
            return await _unitOfWork.CommitAsync();
        }
        public async Task<bool> IsPreferredCellIsGuarantor(long contactPhoneId, CoreEnums.ContactType contactType)
        {
            var contactDetails = await _unitOfWork.GetEntityAsync<ContactDetails>(x => x.Id == contactPhoneId && x.ContactTypeDetails.Id == (long)contactType);
            if (contactDetails.IsNotNull()) return true;
            return false;
        }

        public async Task<IEnumerable<ContactDetails>> GetContactDetailsByIds(List<long> contactDetailsIds)
        {
            return await _unitOfWork.GetAllAsync<ContactDetails>(a => contactDetailsIds.Contains(a.Id));
        }
    }
}
