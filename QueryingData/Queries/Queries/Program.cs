
using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;

namespace Queries
{
    using System.Data.Entity;
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new PlutoContext())
            {
                var authors = ctx.Authors.ToList();
                var authorIds = authors.Select(a => a.Id);

                //load all of the courses whose authors are contained in the list of authors we brought back
                //and which are also free. 
                ctx.Courses.Where(c => authorIds.Contains(c.AuthorId) && c.FullPrice == 0).Load();
            }


        }
    }
}
