using System.Collections.Generic;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;

using Healthware.Core.Base;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IReviewNotesRepository
    {
        Task<long> AddReviewNotes(Entities.ReviewNotes reviewNote);
        Task<IEnumerable<Entities.ReviewNotes>> GetReviewNotes(long assessmentId);
    }
    public class ReviewNotesRepository : IReviewNotesRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;

        public ReviewNotesRepository(IUnitOfWork<PatientDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<long> AddReviewNotes(Entities.ReviewNotes reviewNote)
        {
            _unitOfWork.Attach(reviewNote.Assessment);
            await _unitOfWork.AddAsync(reviewNote);
            await _unitOfWork.CommitAsync();
            return reviewNote.Id;
        }

        public async Task<IEnumerable<Entities.ReviewNotes>> GetReviewNotes(long assessmentId)
        {
            var reviewNotes =
                  await _unitOfWork.GetAllAsync<Entities.ReviewNotes>(x =>
                       x.Assessment.Id == assessmentId);
            return reviewNotes;
        }
    }
}
