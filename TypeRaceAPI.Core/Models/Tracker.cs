using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRaceAPI.Core.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        [NotMapped]
        public Progress progress { get; set; }
        public int progressId { get; set; }
        [NotMapped]
        public Practice practice { get; set; }
        public int practiceId { get; set; }
        public int Score { get; set; }
    }
}
