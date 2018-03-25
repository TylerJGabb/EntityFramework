using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2M_ExplicitlyDefinedMapping_CodeFirst
{
    public class QALabContext : DbContext
    {
        public QALabContext() : base("ManyToMany-TestRequirement") { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<RequirementTestMap> RequirementTestMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Requirement
    {
        public Requirement()
        {
            Tests = new HashSet<Test>();
        }

        [Key]
        public int RequirementId { get; set; }

        [Required]
        public string Name  { get; set; }

        public ICollection<Test> Tests;
    }


    public class Test
    {
        public Test()
        {
            Requirements = new HashSet<Requirement>();
        }

        [Key]
        public int TestId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Requirement> Requirements;
    }

    /// <summary>
    /// Is a many to many relationship
    /// </summary>
    public class RequirementTestMap
    {
        [Key, Column(Order = 0)]
        public int RequirementId { get; set; }

        [Key, Column(Order = 1)]
        public int TestId { get; set; }

        public virtual Requirement Requirement { get; set; }
        public virtual Test Test { get; set; }
    }
}
