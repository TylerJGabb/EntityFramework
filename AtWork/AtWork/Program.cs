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
            string format = "metadata=res://*/Model.csdl|res://*/Model.ssdl|res://*/Model.msl;provider=System.Data.SqlClient;provider connection string=\"{0}\"";
            string connectionString = "data source=PP-MUSTANG;initial catalog=polyprint;persist security info=True;user id=sa;password=MngDBsvr2008@polyprint;MultipleActiveResultSets=True;App=EntityFramework";
            using (var db = new polyprintEntities(String.Format(format, connectionString)))
            {
                var requirements = db.QALabTests.Find(2).QALabTestMaps.Select(m => m.QALabRequirement);
                foreach (var req in requirements)
                {
                    Console.WriteLine(req.Name + " " + req.Description);
                }
                string company = db.QALabTests.Find(2).Address.Company;

            }
        }
    }
}
