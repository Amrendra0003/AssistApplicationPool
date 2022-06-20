using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class PreferedEmail
    {
        public List<PreferredEmailValue> PreferredEmailDropdownValueList { get; set; }
    }
    public class PreferredEmailValue
    {
        public string DisplayTitle { get; set; }
        public string PreferredEmailUniqueId { get; set; }
        public long ContactEmailId { get; set; }
    }
}
