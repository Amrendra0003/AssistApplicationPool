using System.ComponentModel.DataAnnotations.Schema;

namespace Healthware.Core.Entities
{
    [Table("ContactTypeMaster")]
    public class ContactTypeMaster : BaseEntity
    {
        public string EntityType { get; set; }
        public string ContactType { get; set; }
    }
}
