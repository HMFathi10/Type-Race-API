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
        public required Progress progress { get; set; }
        public int progressId { get; set; }
        public required Practice Practice { get; set; }
        public int Score { get; set; }
    }
}
