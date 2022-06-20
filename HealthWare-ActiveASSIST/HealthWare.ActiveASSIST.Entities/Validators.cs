using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    public class Validators : BaseEntity
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int? Max { get; set; }
        public int? Min { get; set; }
        public FieldValidatorType Pattern { get; set; }
    }
}