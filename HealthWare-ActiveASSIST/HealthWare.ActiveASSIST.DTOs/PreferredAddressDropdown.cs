using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class PreferredAddressDropdown
    {
        public List<PreferredAddressDropdownValue> PreferredAddressDropdownValueList { get; set; }
    }
    public class PreferredAddressDropdownValue
    {
        public string DisplayTitle { get; set; }
        public long ContactAddressId { get; set; }
        public string PreferedAddressUniqueId { get; set; }
    }
}
