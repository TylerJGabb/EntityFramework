using System;
using System.Collections.Generic;
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
                var course = ctx.Courses.First().Level = CourseLevel.Intermediate;
                ctx.SaveChanges();
            }
        }
    }
}
