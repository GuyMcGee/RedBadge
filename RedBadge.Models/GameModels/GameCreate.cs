using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        public string Name { get; set; }
    }
}