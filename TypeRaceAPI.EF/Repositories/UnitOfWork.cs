using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Interfaces;
using TypeRaceAPI.Core.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace TypeRaceAPI.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Practice> Practices { get; }

        public IBaseRepository<Tracker> Trackers {  get; }

        public IBaseRepository<Progress> Progresses {  get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Practices = new BaseRepository<Practice>(_context);
            Trackers = new BaseRepository<Tracker>(_context);
            Progresses = new BaseRepository<Progress>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
