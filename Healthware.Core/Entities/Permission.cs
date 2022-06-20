using System.ComponentModel.DataAnnotations;

namespace Healthware.Core.Entities
{
    public class Permission
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}