using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("HouseHoldMemberIncome")]
    public class HouseHoldMemberIncome: BaseEntity
    {
        public HouseHoldMember HouseHoldMember { get; set; }
        public string IncomeType { get; set; }
        public string CurrentStatus { get; set; }
        public string Verification { get; set; }
        public decimal? GrossPay { get; set; }
        public string GrossPayPeriod { get; set; }
        public decimal? CalculatedMonthlyIncome { get; set; }
        public string ContactName { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
}
