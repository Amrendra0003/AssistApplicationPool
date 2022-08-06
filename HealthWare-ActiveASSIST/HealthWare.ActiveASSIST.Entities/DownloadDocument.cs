using Healthware.Core.Entities;
using Healthware.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table("DownloadDocument")]
    public class DownloadDocument 
    {
        [Key]
        public long Id
        {
            get;
            set;
        }
        public long AssessmentId { get; set; }
        public long ProgramDocumentId { get; set; }
        public bool? isDownloaded { get; set; }
       
    }
}
