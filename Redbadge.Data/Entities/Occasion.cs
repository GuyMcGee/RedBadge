using System.ComponentModel.DataAnnotations;

namespace Redbadge.Data.Entities
{
    public class OccasionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime DateTime { get; set; }
    }
}
