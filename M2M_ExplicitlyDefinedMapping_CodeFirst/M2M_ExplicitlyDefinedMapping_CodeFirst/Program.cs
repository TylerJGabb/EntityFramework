using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2M_ExplicitlyDefinedMapping_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test
            {
                Name = "New Test That Does Not Yet Exist"
            };

            var r = new Requirement
            {
                Name = "A New Req which does not yet exist either"
            };

            t.Requirements.Add(r);
            using (var ctx = new QALabContext())
            {
                ctx.Tests.Add(t);
                ctx.SaveChanges();
            }
        }

        public static void UpdateVsInsertPOC()
        {
            using (var ctx = new QALabContext())
            {
                var test = ctx.Tests.Find(1);
                test.Name += test.Name;
                ctx.SaveChanges();
            }
        }


    }
}
