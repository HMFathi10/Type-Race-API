using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Core.Extentions
{
    public static class PracticesExtention
    {
        public static bool? IsPremium(this Practice practice)
        {
            return practice.Premium;
        }
        public static int PassingScore(this Practice practice)
        {
            return practice.PassScore;
        }
    }
}
