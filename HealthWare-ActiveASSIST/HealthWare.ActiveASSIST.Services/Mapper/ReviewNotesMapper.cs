namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IReviewNotesMapper
    {
        Entities.ReviewNotes MapFrom(string reviewNote, long assessmentId, long userId);
    }
    public class ReviewNotesMapper: IReviewNotesMapper
    {
        public Entities.ReviewNotes MapFrom(string reviewNote, long assessmentId, long userId)
        {
            var reviewNotes = new Entities.ReviewNotes
            {
                Assessment = new Entities.Assessment {Id = assessmentId},
                Notes = reviewNote
            };
            return reviewNotes;
        }
    }
}
