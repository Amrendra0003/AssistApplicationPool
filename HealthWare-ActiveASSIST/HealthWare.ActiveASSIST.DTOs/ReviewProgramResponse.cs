using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class ReviewProgramResponse
    {
        public List<ReviewProgramsResponseDto> ReviewPrograms { get; set; }
    }

    public class ReviewProgram
    {
        public long ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string Benefits { get; set; }
        public string Status { get; set; }
        public string BenefitsUrl { get; set; }
    }
}
