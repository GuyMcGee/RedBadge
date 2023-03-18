using System.ComponentModel.DataAnnotations;

namespace RedBadge.Models.IndividualResultsModels
{
    public class IREdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int OccasionId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int RankId { get; set; }
    }
}
