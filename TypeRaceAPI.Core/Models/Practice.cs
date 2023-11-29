using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRaceAPI.Core.Models
{
    public class Practice
    {
        public int Id { get; set; }
        [Required]
        public string Sentence { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public bool Premium { get; set; } = false;
    }
}
