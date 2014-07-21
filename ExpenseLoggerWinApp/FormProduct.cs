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
    public partial class FormProduct : Form,IProductView,ICompaniesView
    {

        CompaniesPresenter presenterCompany;
        ProductPresenter presenterProduct;

        public FormProduct(int id=0)
        {
            InitializeComponent();
            //Set presenters
            presenterCompany = new CompaniesPresenter(this);
            presenterProduct = new ProductPresenter(this);
            //Check if id is not zero to display approprate data.
            if (id > 0)
            {
                presenterProduct.Display(id);
            }
            else
            {
                this.Id = 0;
                this.Text = "New Product";
                buttonDelete.Text = "Cancel";
                buttonSave.Text = "Save";
            }
            //set combobox
            presenterCompany.Display();
            comboBoxCompany.DataSource = Companies;
            comboBoxCompany.DisplayMember = "Name";
            comboBoxCompany.ValueMember = "Id";
        }

        #region IProductView Members

        public int Id
        {
            get;
            set;
        }

        public string ProductName
        {
            get
            {
                return textBoxName.Text.Trim();
            }
            set
            {
                textBoxName.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return textBoxDescription.Text.Trim();
            }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        public int CompanyId
        {
            get
            {
                return Convert.ToInt32(comboBoxCompany.SelectedValue);
            }
            set
            {
                comboBoxCompany.SelectedValue = value;
            }
        }

        #endregion

        #region ICompaniesView Members

        public IList<Company> Companies
        {
            get;
            set;
        }

        #endregion

        private void FormProduct_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            presenterProduct.Save();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
