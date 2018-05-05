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

        //Everything in this constructor is applied directly to the Course entity.
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
                    m.MapLeftKey("CourseId"); //Left key is the course since this is a configuration for the Course class
                    m.MapRightKey("TagId"); //Right key is the Tag, the item we are trying to create a M2M relationship for
                });

            //One To One
            HasRequired(c => c.Cover) 
            .WithRequiredPrincipal(cov => cov.Course); //Principal is the Parent
            //Dependent is the child
        }
    }
}
