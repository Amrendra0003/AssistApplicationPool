using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class ProgramMappingRequest : BasePatientAssessment
    {
        public List<ProgramId> ProgramIdList { get; set; }
        public List<string> ProgramNameList { get; set; }
        public List<UpdateReviewProgramRequest> UpdateReviewProgramRequest { get; set; }
        public bool IsEvaluated { get; set; }

    }
}
