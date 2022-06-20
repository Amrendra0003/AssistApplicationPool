using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetContactDetails
    {
        [Range(1, long.MaxValue, ErrorMessage = Constants.ValidId)]
        [Required(AllowEmptyStrings = false)] public long ContactTypeId { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = Constants.ValidId)]
        public long AssessmentId { get; set; }
    }
}
