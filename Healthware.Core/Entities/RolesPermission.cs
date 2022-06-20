using System.ComponentModel.DataAnnotations;

namespace Healthware.Core.Entities
{
    public class RolesPermission
    {
        [Key]
        public long Id { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}