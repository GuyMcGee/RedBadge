using Microsoft.EntityFrameworkCore;
using RedBadge.Models.GameModels;
using RedBadge.Models.OccasionModels;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.RankModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.IndividualResultsModels
{
    public class IRCreate
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public int OccasionId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int RankId { get; set; }













public List<OccasionListItem>? OccasionOptions { get; set; }
public List<PlayerListItem>? PlayerOptions { get; set; }
        public List<RankListItem>? RankOptions { get; set; }
        public List<GameListItem>? GameOptions { get; set; }
    }
}