using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Service.IServices
{
    public interface IPracticeService
    {
        IEnumerable<Practice> GetPractices();
        Practice? GetPractice(int id);
        void InsertPractice(Practice practice);
        void UpdatePractice(Practice practice);
        void DeletePractice(Practice practice);
    }
}
