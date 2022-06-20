using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("HouseHoldMemberResource")]
    public class HouseHoldMemberResource: BaseEntity
    {
        public HouseHoldMember HouseHoldMember { get; set; }
        public string ResourceType { get; set; }
        public string CurrentStatus { get; set; }
        public string Verification { get; set; }
        public decimal? CurrentMarketValue { get; set; }
        public string Ownership { get; set; }
        public decimal? CalculatedValue { get; set; }
        public string PropertyLocation { get; set; }
    }
}
