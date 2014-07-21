using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExpenseLoggerWinApp.Model;
using ExpenseLoggerWinApp.Presenter;
using ExpenseLoggerWinApp.View;
using Models;

namespace ExpenseLoggerWinApp
{
    
    public partial class FormCompanies : Form,ICompaniesView
    {
        CompaniesPresenter presenter;
        EntityListFormStrategy strategy;

        public FormCompanies()
        {
            InitializeComponent();
            this.presenter = new CompaniesPresenter(this);
            this.strategy = new EntityListFormStrategy(this.dataGridView1);
        }

        #region ICompaniesView Members

        public IList<Company> Companies
        {
            get;
            set;
        }

        #endregion

        #region Events
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefreshDataOnDatagrid();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchString = this.textBoxSearchString.Text.Trim().ToLower();

            if (searchString != string.Empty)
            {
                searchString = searchString.ToLower();
                RefreshDataOnDatagrid();
                dataGridView1.DataSource = Companies.Where(c => c.Name.ToLower().Contains(searchString) || c.Address.ToLower().Contains(searchString)).ToList();
            }
            else
            {
                RefreshDataOnDatagrid();
            }


        }
        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            strategy.DisplayCompanyDetailsForm();
            RefreshDataOnDatagrid();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            strategy.DisplayCompanyDetailsForm(strategy.GetSelectedRowItemId());
            RefreshDataOnDatagrid();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearchString.Text = "";
            RefreshDataOnDatagrid();
        } 
        #endregion

        private void RefreshDataOnDatagrid()
        {
            presenter.Display();
            dataGridView1.DataSource = Companies;
        }
    }
}

