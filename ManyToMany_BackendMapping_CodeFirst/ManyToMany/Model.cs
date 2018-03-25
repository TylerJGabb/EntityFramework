using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany
{
    public class QALabContext : DbContext
    {
        public QALabContext() : base("QALab-DataAnnotations") { }

        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasMany<Requirement>(t => t.Requirements)
                .WithMany(r => r.Tests)
                .Map(map =>
                    {
                        map.MapLeftKey("TestId");
                        map.MapRightKey("RequirementId");
                        map.ToTable("QALabTest_Map");
                    });
        }
    }

    public class Test
    {
        public Test()
        {
            this.Requirements = new HashSet<Requirement>();
        }

        public int TestId { get; set; }

        [Required]
        public string Name { get; set; }
    
        public virtual ICollection<Requirement> Requirements { get; set; }
    }

    public class Requirement
    {
        public Requirement()
        {
            this.Tests = new HashSet<Test>();
        }

        public int RequirementId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Test> Tests { get; set;}
    }
}
