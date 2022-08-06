using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthWare.ActiveASSIST.Entities.Mappings
{
    [Table("FacilityMapping")]
    public class FacilityMapping
    {
        [Key]
        public long Id
        {
            get;
            set;
        }
        public long UserId { get; set; }   
        public long FacilityId { get; set; }
        public string FacilityCode { get; set; }
    }
}
