using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("Document")]
    public class Document : BaseEntity
    {
        public Assessment Assessment { get; set; }
        public DocumentTypeMaster DocumentTypeMaster { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Checksum { get; set; }

        public static implicit operator DTOs.VerificationDocument(Document document)
        {
            if (document.IsNotNull())
            {
                return new DTOs.VerificationDocument()
                {
                    DocumentId = document.Id,
                    DocumentName = document.Name,
                    DocumentType = document.DocumentTypeMaster.DocumentTypeName
                };
            }

            return null;

        }
    }
}
