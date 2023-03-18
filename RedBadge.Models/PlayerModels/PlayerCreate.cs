using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.PlayerModels
{
    public class PlayerCreate
    {
        [Required]
        [MaxLength(21, ErrorMessage = "Cannot exceed 21 characters")]
        [MinLength(1, ErrorMessage = "Must have at least 1 character")]
        public string Name { get; set; } = null!;
    }
}
