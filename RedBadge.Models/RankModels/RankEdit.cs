using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.RankModels
{
    public class RankEdit
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Cannot exceed 64 characters")]
        [MinLength(1, ErrorMessage = "Must have at least 1 character")]
        public string RankName { get; set; } = null!;
    }
}
