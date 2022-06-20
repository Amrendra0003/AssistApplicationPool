using System.Collections.Generic;
using System.Linq;
using HealthWare.ActiveASSIST.Entities.DropDown;

namespace HealthWare.ActiveASSIST.Entities.Master
{
    public static class Genders
    {
        public static readonly Gender Male = new Gender { Id = 1, Value = male, KeyName = "M" };
        public static readonly Gender Female = new Gender { Id = 2, Value = female, KeyName = "F" };
        public static readonly Gender Unknown = new Gender { Id = 3, Value = unknown, KeyName = "U" };

        public static IEnumerable<Gender> All()
        {
            yield return Male;
            yield return Female;
            yield return Unknown;
        }

        public static Gender FindBy(long? id)
        {
            return All().Single(x => x.Id == id);
        }

        private const string male = "Male";
        private const string female = "Female";
        private const string unknown = "Unreported or Unknown";
    }
}
