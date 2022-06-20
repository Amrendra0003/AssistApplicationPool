using System.ComponentModel.DataAnnotations;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class GetPatientNamesRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        public long AdvocateId { get; set; }
    }
}
