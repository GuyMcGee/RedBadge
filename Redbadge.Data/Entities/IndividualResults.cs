using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Redbadge.Data.Entities
{
    public class IndividualResultsEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(GameEntity))]
        public int GameId { get; set; }
        public GameEntity Game { get; set; } = null!;


        [ForeignKey(nameof(OccasionEntity))]
        public int OccasionId { get; set; }
        public OccasionEntity Occasion { get; set; } = null!;


        [ForeignKey(nameof(PlayerEntity))]
        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; } = null!;


        [ForeignKey(nameof(RankEntity))]
        public int RankId { get; set; }
        public RankEntity Rank { get; set; } = null!;
    }
}
