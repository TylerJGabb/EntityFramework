
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
                var courses = ctx.Courses;
                int end = courses.Count();

                for (int i = 0; i < end; i++)
                {
                    Console.WriteLine(courses.OrderBy(c => c.Id).Skip(i).Take(1).First());
                }

            }
        }
    }
}
