using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.PlayerModels
{
    public class PlayerDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
