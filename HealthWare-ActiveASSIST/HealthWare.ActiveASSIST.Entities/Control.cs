using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class Control
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public string ControlType { get; set; }
        public string HelpText { get; set; }
        public string ContextHelp { get; set; }
    }
}
