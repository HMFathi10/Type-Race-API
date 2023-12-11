using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRaceAPI.Service.IServices
{
    public interface IUnitOfService
    {
        IPracticeService practiceService { get; }
        IProgressService progressService { get; }
        ITrackerService trackerService { get; }
    }
}
