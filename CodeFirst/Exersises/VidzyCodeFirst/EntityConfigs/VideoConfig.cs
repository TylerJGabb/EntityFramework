using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidzyCodeFirst.Models;

namespace VidzyCodeFirst.EntityConfigs
{
    class VideoConfig : EntityTypeConfiguration<Video>
    {
        public VideoConfig()
        {
            
                Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            
                HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            
                HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .Map(m =>
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("VideoId");
                    m.MapRightKey("TagId");
                });
        }
    }
}
