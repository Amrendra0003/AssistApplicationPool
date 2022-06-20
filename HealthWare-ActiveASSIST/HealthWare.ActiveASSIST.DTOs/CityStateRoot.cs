using System.Collections.Generic;
using Newtonsoft.Json;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class CityStateRoot
    {
        [JsonProperty(Constants.PostCode)]
        public string PostCode { get; set; }
        public string Country { get; set; }

        [JsonProperty(Constants.CountryAbbreviation)]
        public string CountryAbbreviation { get; set; }
        public List<Place> Places { get; set; }
    }
    public class Place
    {
        [JsonProperty(Constants.PlaceName)]
        public string PlaceName { get; set; }
        public string State { get; set; }

        [JsonProperty(Constants.StateAbbreviation)]
        public string StateAbbreviation { get; set; }
        public string Latitude { get; set; }
    }
}
