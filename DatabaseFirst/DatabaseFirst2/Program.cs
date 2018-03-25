using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst2
{
    class Program
    {
        static void Main(string[] args)
        {

            var req = new QALabRequirement
            {
                Name = "12345"
            };
            AddNewRequirementToTest(5, req);
                      
        }

        /// <summary>
        /// Can not have nested contexts. Is bad idea. find the record number and pass it in to this function. 
        /// the context handles the logic from there. 
        /// 
        /// Otherwise, exit scope of the context used to find the existing requirement. 
        /// then pass the requirement to an overload of this function. 
        /// </summary>
        /// <param name="reqId"></param>
        /// <param name="testId"></param>
        static void AddExistingRequirementToTest(int reqId, int testId)
        {
            using (var db = new DatabaseFirstEntities())
            {
                var req = db.QALabRequirements.Find(9);
                db.QALabTests.Find(5).QALabTestMaps.Add(new QALabTestMap
                {
                    QALabRequirement = req,
                    QALabTest_Number = 5
                });
                db.SaveChanges();
            }
        }

        static void AddNewRequirementToTest(int testId, QALabRequirement req)
        {
            using (var db = new DatabaseFirstEntities())
            {
                db.QALabTests.Find(testId).QALabTestMaps.Add(new QALabTestMap
                {
                    QALabRequirement = req,
                    QALabTest_Number = testId
                });
                db.SaveChanges();
            }
        }

        static void PrintRequirementsForTest(int test_rec_num)
        {
            using (var db = new DatabaseFirstEntities())
            {
                var requirements = db.QALabTests.Find(test_rec_num).QALabTestMaps.Select(m => m.QALabRequirement);
                foreach (var req in requirements)
                {
                    Console.WriteLine($"{req.Record_Number} -- {req.Name}");
                }
            }
        }
    }
}
