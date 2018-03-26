using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AtWork
{
    
    class Program
    {   [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }

        /// <summary>
        /// WARNING, must be closed by the caller!
        /// </summary>
        /// <returns></returns>
        public static polyprintEntities GetContext()
        {
            Console.WriteLine("Program: A new context was handed out.\n" +
                "Plan later tracking with implimentation of IDisposable and overriding Dispose to signal disposal");
            return new polyprintEntities();
        }
    }
}
