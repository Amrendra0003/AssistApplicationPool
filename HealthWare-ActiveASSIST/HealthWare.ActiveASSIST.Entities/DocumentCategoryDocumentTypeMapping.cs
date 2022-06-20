using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.Entities
{
    public class DocumentCategoryDocumentTypeMapping
    {
        [Key]
        public long Id { get; set; }
        public DocumentCategoryMaster DocumentCategoryMaster { get; set; }
        public DocumentTypeMaster DocumentTypeMaster { get; set; }
    }
}
