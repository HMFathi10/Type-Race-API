using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Service.IServices;

namespace TypeRaceAPI.Service.Services
{
    public class UnitOfService : IUnitOfService
    {
        public IPracticeService practiceService { get; }
        public IProgressService progressService { get; }
        public ITrackerService trackerService { get; }
        private readonly IMemoryCache _memoryCache;

        public UnitOfService(IMemoryCache memoryCache, IProgressService progressService, IPracticeService practiceService, ITrackerService trackerService)
        {
            _memoryCache = memoryCache;
            this.progressService = progressService;
            this.trackerService = trackerService;
            this.practiceService = practiceService;
        }

    }
}
