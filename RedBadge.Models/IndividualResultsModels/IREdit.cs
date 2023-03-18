using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
