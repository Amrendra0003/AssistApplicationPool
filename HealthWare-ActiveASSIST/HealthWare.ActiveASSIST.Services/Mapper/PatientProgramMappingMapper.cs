namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IPatientProgramMappingMapper
    {
        Entities.PatientProgramMapping MapFrom(long assessmentId, long programId, bool isEvaluated);
    }
    public class PatientProgramMappingMapper : IPatientProgramMappingMapper
    {
        public Entities.PatientProgramMapping MapFrom(long assessmentId, long programId, bool isEvaluated)
        {
            var patientProgramMapping = new Entities.PatientProgramMapping()
            {
                Assessment = new Entities.Assessment() { Id = assessmentId },
                Program = new Entities.Program() { Id = programId },
                IsActive = true,
                IsEvaluated = isEvaluated
            };
            return patientProgramMapping;
        }
    }
}
