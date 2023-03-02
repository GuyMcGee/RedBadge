using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        [MaxLength(255,ErrorMessage = "Cannot exceed 255 characters")]
        [MinLength(2, ErrorMessage = "Must have at least 2 characters")]
        public string Name { get; set; } = null!;
    }
}