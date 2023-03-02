using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.GameModels
{
    public class GameDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
