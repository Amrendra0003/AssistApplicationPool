using System.ComponentModel.DataAnnotations.Schema;
using Healthware.Core.Constants;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    [Table(Application.ReviewNotes)]
    public class ReviewNotes: BaseEntity
    {
        public Assessment Assessment { get; set; }
        public string Notes { get; set; }
    }
}
