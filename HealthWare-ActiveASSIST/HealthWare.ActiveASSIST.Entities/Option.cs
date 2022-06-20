using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    public class Option : BaseEntity
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}