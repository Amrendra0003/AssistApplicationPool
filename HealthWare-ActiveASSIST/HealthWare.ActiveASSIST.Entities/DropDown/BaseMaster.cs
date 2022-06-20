using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities.DropDown
{
    public abstract class BaseMaster
    {
        [Key]
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string Value { get; set; }
    }
}
