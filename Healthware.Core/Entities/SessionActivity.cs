using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healthware.Core.Entities
{
    [Table("SessionActivity")]
    public class SessionActivity : BaseEntity
    {
        public MainUser User { get; set; }
        public DateTime SessionStartDateTime { get; set; }
        public DateTime LastLoggedInDateTime { get; set; }
        public bool Active { get; set; }
    }
}
