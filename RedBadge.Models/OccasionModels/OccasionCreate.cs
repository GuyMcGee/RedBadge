using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.OccasionModels
{
    public class OccasionCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        [MinLength(1, ErrorMessage = "Must have at least 1 character")]
        public string Name { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
