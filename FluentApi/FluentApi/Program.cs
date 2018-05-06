using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new PlutoDbContext())
            {
                IEnumerable<Course> courses = ctx.Courses;
                var filter = courses
                    .Where(c => c.Level == CourseLevel.Intermediate);
                foreach (var course in filter)
                {
                    Console.WriteLine(course.Title);
                }
            }
        }
    }
}
