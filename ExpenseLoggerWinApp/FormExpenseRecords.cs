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
    public partial class FormExpenseRecords : Form,IExpenseRecordsView
    {
        ExpenseRecordsPresenter presenter;
        EntityListFormStrategy strategy;

        public FormExpenseRecords()
        {
            InitializeComponent();
            this.presenter = new ExpenseRecordsPresenter(this);
            this.strategy = new EntityListFormStrategy(this.dataGridView1);
        }

        #region Events
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchString = this.textBoxSearchString.Text.Trim().ToLower();

            RefreshDataOnDatagrid();
            if (searchString != string.Empty)
            {
                searchString = searchString.ToLower();
                dataGridView1.DataSource = ExpenseRecords.Where(c => 
                    c.Description.ToLower().Contains(searchString) 
                    || c.Product.Name.ToLower().Contains(searchString) 
                    || c.Product.Company.Name.ToLower().Contains(searchString)
                    ).ToList();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearchString.Text = "";
            RefreshDataOnDatagrid();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            strategy.DisplayExpenseRecordDetailsForm();
            RefreshDataOnDatagrid();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            strategy.DisplayExpenseRecordDetailsForm(strategy.GetSelectedRowItemId());
            RefreshDataOnDatagrid();
        }

        private void FormExpenseRecords_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefreshDataOnDatagrid();
        } 
        #endregion

        #region IExpenseRecordsView Members

        public IList<ExpenseRecord> ExpenseRecords
        {
            get;
            set;
        }

        #endregion

        private void RefreshDataOnDatagrid()
        {
            presenter.Display();
            dataGridView1.DataSource = ExpenseRecords;
        }

    }
}
