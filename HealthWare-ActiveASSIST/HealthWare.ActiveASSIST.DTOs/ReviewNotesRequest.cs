using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class ReviewNotesRequest
    {
        public List<string> ReviewNotes { get; set; }
        public long UserId { get; set; }
        public long AssessmentId  { get; set; }
        public List<SubmittedProgram> ProgramIdList  { get; set; }
        public List<UpdateReviewProgramRequest> UpdateReviewProgramRequest { get; set; }
    }

    public class SubmittedProgram
    {
        public long Id { get; set; }
    }
}
