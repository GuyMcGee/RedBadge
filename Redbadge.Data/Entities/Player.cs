using System.ComponentModel.DataAnnotations;

namespace Redbadge.Data.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
