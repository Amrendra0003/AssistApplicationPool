using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("Program")]
    public class Program: BaseEntity
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string BenefitsDescriptionUrl { get; set; }

    }
}
