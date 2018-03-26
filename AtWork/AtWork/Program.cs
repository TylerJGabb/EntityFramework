using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtWork
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new polyprintEntities())
            {
                IEnumerable<QALabRequirement> list = db.QALabRequirements.ToList();
            }
        }
    }
}
