using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Service.Services
{
    public class TrackerService : ITrackerService
    {
        private IUnitOfWork unitOfWork;
        public TrackerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void DeleteTracker(Tracker tracker)
        {
            throw new NotImplementedException();
        }

        public Tracker? GetTracker(Tracker tracker)
        {
            return unitOfWork.Trackers.Get(tracker.Id);
        }

        public IEnumerable<Tracker?> GetTrackers(Expression<Func<Tracker, bool>> predicate, string[]? include = null)
        {
            var result = unitOfWork.Trackers.FindAll(predicate, includes: include);
            return result;
        }

        public IEnumerable<Tracker?> GetTrackers()
        {
            return unitOfWork.Trackers.GetAll();
        }

        public void InsertTracker(Tracker tracker)
        {
            unitOfWork.Trackers.Add(tracker);
        }

        public void UpdateTracker(Tracker tracker)
        {
            throw new NotImplementedException();
        }
    }
}
