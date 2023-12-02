using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Core
{
    public class PracticeViewModel
    {
        public int Id { get; set; }
        public string Sentence { get; set; }
        public int level { get; set; }
        public bool Premium { get; set; }
        public int? TrackerId { get; set; }
        public int Score { get; set; } = 0;
        public int? ProgressId { get; set; }
    }
}
