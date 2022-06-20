using System.ComponentModel.DataAnnotations;

namespace Healthware.Core.Entities
{
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public string RoleName { get; set; }
    }
}