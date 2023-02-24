using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.IndividualResultsModels
{
    internal class IRCreate
    {
        public int GameId { get; set; }
        public int OccasionId { get; set; }
        public int PlayerId { get; set; }
        public int RankId { get; set; }
    }
}
