using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new QALabContext())
            {
                var t = ctx.Tests.Find(10);

                
            }

        }

        public static void AddNonExistingRequirementToExistingTest(string reqName, int existingTestId)
        {
            var newReq = new Requirement
            {
                Name = reqName
            };


            using (var ctx = new QALabContext())
            {
                var test = ctx.Tests.Find(existingTestId);
                test.Requirements.Add(newReq);
                ctx.SaveChanges();
            }
        }

        public static void AddExistingRequirementToExistingTest(int testId, int reqId)
        {
            using (var ctx = new QALabContext())
            {
                var req = ctx.Requirements.Find(reqId);
                var tst = ctx.Tests.Find(testId);
                tst.Requirements.Add(req);
                ctx.SaveChanges();
            }
        }

        public static void AddExistingTestToExistingRequirement(int reqId, int testId)
        {
            using (var ctx = new QALabContext())
            {
                var req = ctx.Requirements.Find(reqId);
                var tst = ctx.Tests.Find(testId);
                req.Tests.Add(tst);
                ctx.SaveChanges();
            }
        }

        public static void DemonstrateCreation()
        {
            Console.Write("Enter new test name: ");
            var tst = NewTest(Console.ReadLine().Trim());
            Console.Write("Enter new requirement name: ");
            var req = NewRequirement(Console.ReadLine().Trim());
            Console.WriteLine("Notice how EF6 has created multiple rows in attempts to apply a mapping to already existing objects");
            Console.Read();
        }

        /// <summary>
        /// Makes a new requirement in the database with the given name, returns the newly entried requirement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static Requirement NewRequirement(string name)
        {
            Requirement req = new Requirement
            {
                Name = name
            };

            using (var ctx = new QALabContext())
            {
                ctx.Requirements.Add(req);
                ctx.SaveChanges();
                req = (from r in ctx.Requirements where r.RequirementId == ctx.Requirements.Select(re => re.RequirementId).Max() select r).Single();
            }
            return req;
        }


        /// <summary>
        /// Makes a new test in the database with the given name. Is Slow
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static Test NewTest(string name)
        {
            Test tst = new Test
            {
                Name = name
            };
            using (var ctx = new QALabContext())
            {
                ctx.Tests.Add(tst);
                ctx.SaveChanges();
                tst = (from t in ctx.Tests where t.TestId == ctx.Tests.Select(te => te.TestId).Max() select t).Single();
            }
            return tst;
        }
    }


}
