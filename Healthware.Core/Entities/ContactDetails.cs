using System.ComponentModel.DataAnnotations.Schema;

namespace Healthware.Core.Entities
{
    [Table("ContactDetails")]
    public class ContactDetails: BaseEntity
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public ContactTypeMaster ContactTypeDetails { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string Cell { get; set; }
        public string Fax { get; set; }
        public string CountyCode { get; set; }
        public string Email { get; set; }
        public string PhoneType { get; set; }
        public string StateCode { get; set; }
    }
}
