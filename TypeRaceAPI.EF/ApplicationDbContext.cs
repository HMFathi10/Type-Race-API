using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.ModelMap;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.EF
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new PracticeMap(builder.Entity<Practice>());
            new ProgressMap(builder.Entity<Progress>());
            new TrackerMap(builder.Entity<Tracker>());
            //builder.Entity<Tracker>().HasOne<Progress>(t => t.progress).WithMany(p => p.Trackers).HasForeignKey(t => t.progressId);
            //builder.Entity<Tracker>().HasOne<Practice>(t => t.Practice).WithMany(p => p.trackers).HasForeignKey(t => t.practiceId);
        }
        //public DbSet<Progress> progresses { get; set; }
        //public DbSet<Tracker> trackers { get; set; }
        //public DbSet<Practice> practices { get; set; }
    }
}
