using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.IndividualResultsModels
{
    internal class IRListItem
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int OccasionId { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public int RankId { get; set; }
    }
}
