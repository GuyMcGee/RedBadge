using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models.OccasionModels
{
    internal class OccasionCreate
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }
}
