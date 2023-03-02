using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redbadge.Data.Entities
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RankName { get; set; } = null!;
    }
}
