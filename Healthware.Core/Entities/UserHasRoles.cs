using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthware.Core.Entities
{
    [Table("UserHasRoles")]
    public class UserHasRoles
    {
        [Key]
        public long Id { get; set; }
        public MainUser User { get; set; }
        public Role Role { get; set; }
    }
}
