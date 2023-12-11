using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeRaceAPI.Core.Models;

namespace TypeRaceAPI.Core.ModelMap
{
    public class ProgressMap
    {
        public ProgressMap(EntityTypeBuilder<Progress> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(p => p.speedRate).IsRequired();
            entityTypeBuilder.Property(p => p.Level).IsRequired();
            entityTypeBuilder.Property(p => p.UserId).IsRequired();
        }
    }
}
