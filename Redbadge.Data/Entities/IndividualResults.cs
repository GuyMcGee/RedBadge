using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redbadge.Data.Entities
{
    public class IndividualResults
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(GameEntity))]
        public int GameId { get; set; }

        [ForeignKey(nameof(OccasionEntity))]
        public int OccasionId { get; set; }

        
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }


        [ForeignKey(nameof(Rank))]
        public int RankId { get; set; }
    }
}
