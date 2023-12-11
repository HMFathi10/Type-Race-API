using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Service.IServices
{
    public interface IProgressService
    {
        IEnumerable<Progress?> GetProgresses(Expression<Func<Progress, bool>> predicate, string[]? include = null);
        IEnumerable<Progress?> GetProgresses();
        Progress? GetProgress(int progress);
        void InsertProgress(Progress progress);
        void UpdateProgress(Progress progress);
        void DeleteProgress(Progress progress);
    }
}
