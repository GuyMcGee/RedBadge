using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.GameModels
{
    public class GameEdit
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        [MinLength(2, ErrorMessage = "Must have at least 2 characters")]
        public string Name { get; set; } = null!;
    }
}
