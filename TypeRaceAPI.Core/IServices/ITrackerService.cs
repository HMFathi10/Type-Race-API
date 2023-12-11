using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Service.IServices
{
    public interface ITrackerService
    {
        //IEnumerable<Tracker> GetTrackers();
        IEnumerable<Tracker?> GetTrackers(Expression<Func<Tracker, bool>> predicate, string[]? include = null);
        IEnumerable<Tracker?> GetTrackers();
        Tracker? GetTracker(Tracker tracker);
        void InsertTracker(Tracker tracker);
        void UpdateTracker(Tracker tracker);
        void DeleteTracker(Tracker tracker);

    }
}
