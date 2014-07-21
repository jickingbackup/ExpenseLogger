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
    public partial class FormProducts : Form,IProductsView
    {
        ProductsPresenter presenter;
        EntityListFormStrategy strategy;
        
        public FormProducts()
        {
            InitializeComponent();
            this.presenter = new ProductsPresenter(this);
            this.strategy = new EntityListFormStrategy(this.dataGridView1);
        }

        #region Events
        private void FormProducts_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefreshDataOnDatagrid();
        }
        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            strategy.DisplayProductDetailsForm();
            RefreshDataOnDatagrid();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            strategy.DisplayProductDetailsForm(strategy.GetSelectedRowItemId());
            RefreshDataOnDatagrid();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchString = this.textBoxSearchString.Text.Trim().ToLower();

            RefreshDataOnDatagrid();
            if (searchString != string.Empty)
            {
                searchString = searchString.ToLower();
                dataGridView1.DataSource = Products.Where(c => 
                    c.Name.ToLower().Contains(searchString) || 
                    c.Description.ToLower().Contains(searchString)
                    ).ToList();
            }
            
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
            dataGridView1.DataSource = Products;
        } 

        #region IProductsView Members

        public IList<Product> Products
        {
            get;
            set;
        }

        #endregion
    }
}
