using System.ComponentModel.DataAnnotations;


namespace Redbadge.Data.Entities
{
    public class GameEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }
    }
}
