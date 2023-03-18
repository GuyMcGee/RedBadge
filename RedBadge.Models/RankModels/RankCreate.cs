using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.RankModels
{
    public class RankCreate
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Cannot exceed 30 characters")]
        [MinLength(1, ErrorMessage = "Must have at least 1 character")]
        public string RankName { get; set; } = null!;
    }
}
