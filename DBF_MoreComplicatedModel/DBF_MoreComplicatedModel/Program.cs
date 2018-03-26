using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBF_MoreComplicatedModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RandomEntities())
            {
                ////customer to all of its requirements
                //var anniesTests = db.Customers.Find(1).Tests.SelectMany(t => t.TestMaps).Select(m => m.Requirement);

                //You can not remove a test from a customer because all this does is set the Customer_Record_Number field for the test to Null.
                //Since this is not a NULLABLE FK, an exception is thrown and the save is not made. 

                //remove a single test
                var badTest = db.Customers.Find(1).Tests.First();
                db.Tests.Remove(badTest);
                db.SaveChanges();
            }
        }
    }
}
