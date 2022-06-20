using HealthWare.ActiveASSIST.Entities;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IProgramMapper
    {
        Program MapFrom(string programName, string programDescription, string programBenefitsUrl);
    }
    public class ProgramMapper: IProgramMapper
    {
        public Program MapFrom(string programName, string programDescription, string programBenefitsUrl)
        {
            var program = new Program
            {
                Name = programName,
                Details = programDescription,
                BenefitsDescriptionUrl = programBenefitsUrl
            };
            return program;
        }
    }
}
