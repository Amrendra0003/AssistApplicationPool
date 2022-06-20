using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class Screen
    {
        [Key] public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Order { get; set; }
        public string Content { get; set; }
        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
    }
}