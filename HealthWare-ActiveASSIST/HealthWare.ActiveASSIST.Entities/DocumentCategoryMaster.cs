using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class DocumentCategoryMaster
    {
        [Key]
        public long Id { get; set; }
        public string CategoryName { get; set; }
    }
}
