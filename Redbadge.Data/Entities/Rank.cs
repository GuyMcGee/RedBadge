using System.ComponentModel.DataAnnotations;


namespace Redbadge.Data.Entities
{
    public class RankEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RankName { get; set; } = null!;
    }
}
