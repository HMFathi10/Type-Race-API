using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRaceAPI.Core.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        [Required]
        public Progress progressId { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
    }
}
