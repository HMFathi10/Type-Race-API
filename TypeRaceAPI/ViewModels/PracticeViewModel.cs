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

        public PracticeViewModel(int Id, string Sentence, int level, bool Premium, int? TrackerId = null, int Score = 0, int? ProgressId = null)
        {
            this.Id = Id;
            this.Sentence = Sentence;
            this.Score = Score;
            this.level = level;
            this.Premium = Premium;
            this.TrackerId = TrackerId;
            this.ProgressId = ProgressId;
        }
    }
}
