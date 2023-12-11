using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRaceAPI.Core.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public int speedRate { get; set; } = 0;
        public int Level { get; set; } = 1;
        public required string UserId { get; set; }
        public List<Tracker>? trackers { get; set; }
    }
}
