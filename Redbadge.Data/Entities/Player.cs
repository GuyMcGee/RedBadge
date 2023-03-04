using System.ComponentModel.DataAnnotations;

namespace Redbadge.Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
