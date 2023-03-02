using RedBadge.Models.GameModels;
using RedBadge.Models.OccasionModels;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.RankModels;

namespace RedBadge.Models.IndividualResultsModels
{
    internal class IRDetails
    {
        public int Id { get; set; }
        public GameListItem Game { get; set; } = null!;
        public OccasionListItem Occasion { get; set; } = null!;
        public PlayerListItem Player { get; set; } = null!;
        public RankListItem Rank { get; set; } = null!;
    }
}
