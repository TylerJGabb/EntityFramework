using CodeFirstNewDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new PlutoDbContext())
            {
                var author = new Author()
                {
                    
                };
            }
        }
    }
}
