using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Core.ModelMap
{
    public class TrackerMap
    {
        public TrackerMap(EntityTypeBuilder<Tracker> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(t => t.Score).IsRequired();
            entityTypeBuilder.HasOne<Progress>(t => t.progress).WithMany(p => p.trackers).HasForeignKey(t => t.progressId).OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.HasOne<Practice>(t => t.practice).WithMany(p => p.trackers).HasForeignKey(t => t.practiceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
