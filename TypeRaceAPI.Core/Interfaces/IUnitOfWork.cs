using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Practice> Practices { get; }
        IBaseRepository<Tracker> Trackers { get; }
        IBaseRepository<Progress> Progresses { get; }
        int Complete();

    }
}
