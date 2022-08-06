using Healthware.Core.Entities;
using HealthWare.ActiveASSIST.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("Facilities")]
    public class Facilities : BaseEntity
    {
        public string FacilityName { get; set; }
        public string AccessGroupID { get; set; }
        public string FacilityCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
