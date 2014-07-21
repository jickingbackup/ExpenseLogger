using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseLoggerWinApp
{
    public partial class FormMain : Form
    {
        //holds initialized form
        List<Form> forms = new List<Form>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCompanies form = new FormCompanies();
            DisplayNewForm(form);
        }

        /// <summary>
        /// Encapsulates the process of displaying and disposing recent active form.
        /// </summary>
        /// <param name="form"></param>
        void DisplayNewForm(Form form)
        {
            foreach(var item in forms )
            {
                item.Dispose();
            }

            forms.Clear();
            forms.Add(form);

            form.MdiParent = this;
            form.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProducts form = new FormProducts();
            DisplayNewForm(form);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormCompanies form = new FormCompanies();
            DisplayNewForm(form);
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExpenseRecords form = new FormExpenseRecords();
            DisplayNewForm(form);
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewExpenseRecordsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpenseLoggerWinApp.Reports.FormReportViewer form = new Reports.FormReportViewer();
            form.ShowDialog();
        }
    }
}
