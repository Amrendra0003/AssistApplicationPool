using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class PreferedCell
    {
        public List<PreferedCellValue> PreferredCellDropdownValueList { get; set; }
    }
    public class PreferedCellValue
    {
        public string DisplayTitle { get; set; }
        public string PreferredPhoneUniqueId { get; set; }
        public long ContactPhoneId { get; set; }
    }
}
