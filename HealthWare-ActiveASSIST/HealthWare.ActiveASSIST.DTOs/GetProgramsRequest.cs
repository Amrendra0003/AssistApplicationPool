using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetProgramsRequest
    {
        public List<ProgramId> ProgramIdList { get; set; }
    }

    public class ProgramId
    {
        public long Id { get; set; }
    }
}
