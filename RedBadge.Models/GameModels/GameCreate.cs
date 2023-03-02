using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        [MaxLength(64,ErrorMessage = "Cannot exceed 64 characters")]
        [MinLength(1, ErrorMessage = "Must have at least 1 character")]
        public string Name { get; set; } = null!;
    }
}