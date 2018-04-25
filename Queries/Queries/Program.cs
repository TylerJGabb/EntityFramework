
using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new PlutoContext())
            {
                //Get all courses in level 1, order by name descending then description descending
                var courses =
                    ctx.Courses
                        .Where(c => c.Level == 1)
                        .OrderByDescending(c => c.Name)
                        .ThenByDescending(c => c.Description)
                        .Select(c => new
                        {
                            Name = c.Name,
                            Description = c.Description
                        });

            }
        }
    }
}
