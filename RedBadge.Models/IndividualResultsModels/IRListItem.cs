namespace RedBadge.Models.IndividualResultsModels
{
    public class IRListItem
    {
        public int Id { get; set; }
        public string GameName { get; set; } = null!;
        public string OccasionName { get; set; } = null!;
        public string PlayerName { get; set; } = null!;
        public string RankName { get; set; } = null!;
    }
}
