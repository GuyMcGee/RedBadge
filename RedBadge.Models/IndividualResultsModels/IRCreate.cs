using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.IndividualResultsModels
{
    public class IRCreate
    {
        public int GameId { get; set; } //Why does this not have to be declared as "!null"?
        public int OccasionId { get; set; }
        public int PlayerId { get; set; }
        public int RankId { get; set; }
    }
}
