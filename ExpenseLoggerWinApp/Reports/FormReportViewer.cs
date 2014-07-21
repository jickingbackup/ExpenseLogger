using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Models;
using ExpenseLoggerWinApp.Model;
namespace ExpenseLoggerWinApp.Reports
{
    public partial class FormReportViewer : Form
    {
        IModel model = new Model.Model();

        public FormReportViewer()
        {
            InitializeComponent();
        }

        private void FormReportViewer_Load(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            IList<Company> companies = model.GetAllCompany();
            
            
            //Add to report
            foreach (var i in companies)
            {
                CompanyBindingSource.Add(i);
            }
            this.reportViewer1.RefreshReport();
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
    }
}
