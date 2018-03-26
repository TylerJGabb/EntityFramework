using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtWork
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            using (var db = Program.GetContext())
            {
                cbTests.DataSource = db.QALabTests.ToList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var test = (QALabTest)cbTests.SelectedItem;
            Console.WriteLine($"MyForm: Deleting Test {test}");
            using (var db = Program.GetContext())
            {
                db.QALabTests.Remove(db.QALabTests.Find(test.Record_Number));
                db.SaveChanges();
            }
        }
    }
}
