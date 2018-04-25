using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.EntityConfigurations;

namespace FluentApi
{
    class PlutoDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PlutoDbContext() : base("name=NewPluto")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CoverConfiguration());
        }
    }
}
