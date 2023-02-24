using RedBadge.Models.GameModels;
using RedBadge.Models.OccasionModels;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.RankModels;

namespace RedBadge.Models.IndividualResultsModels
{
    internal class IRDetails
    {
        public int Id { get; set; }
        public GameListItem Game { get; set; }
        public OccasionListItem Occasion { get; set; }
        public PlayerListItem Player { get; set; }
        public RankListItem Rank { get; set; }
    }
}
