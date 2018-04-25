using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.EntityConfigurations
{
    class CoverConfiguration : EntityTypeConfiguration<Cover>
    {
        public CoverConfiguration()
        {
                Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
