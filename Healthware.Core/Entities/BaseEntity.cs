using System;
using System.ComponentModel.DataAnnotations;

namespace Healthware.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }        
        public DateTime? UpdatedDate { get; set; }
    }
}
