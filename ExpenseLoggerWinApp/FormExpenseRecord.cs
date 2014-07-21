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
    public partial class FormExpenseRecord : Form,IExpenseRecordView,IProductsView
    {
        ProductsPresenter productsPresenter;
        ExpenseRecordPresenter recordPresenter;

        public FormExpenseRecord(int id=0)
        {
            InitializeComponent();

            //Set presenters
            productsPresenter = new ProductsPresenter(this);
            recordPresenter = new ExpenseRecordPresenter(this);
            //Check if id is not zero to display approprate data.
            if (id > 0)
            {
                recordPresenter.Display(id);
            }
            else
            {
                this.Id = 0;
                this.Text = "New Product";
                buttonDelete.Text = "Cancel";
                buttonSave.Text = "Save";
            }
            //set combobox
            productsPresenter.Display();
            comboBoxProduct.DataSource = Products;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.ValueMember = "Id";
        }

        #region IExpenseRecordView Members

        public int Id
        {
            get;
            set;
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

        public decimal Amount
        {
            get
            {
                return numericUpDownPrice.Value;
            }
            set
            {
                numericUpDownPrice.Value = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return dateTimePicker1.Value;
            }
            set
            {
                dateTimePicker1.Value = value;
            }
        }

        public int ProductId
        {
            get
            {
                return Convert.ToInt32( comboBoxProduct.SelectedValue);
            }
            set
            {
                comboBoxProduct.SelectedValue = value;
            }
        }

        #endregion

        #region IProductsView Members

        public IList<Product> Products
        {
            get;
            set;
        }

        #endregion

        private void FormExpenseRecord_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            recordPresenter.Save();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
