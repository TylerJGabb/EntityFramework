using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {

        public CourseConfiguration()
        {

            //Properties
            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(255);


            //Relationships
            //One To Many
            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            //Many To Many
            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });

            //One To One
            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(cov => cov.Course);
        }
    }
}
