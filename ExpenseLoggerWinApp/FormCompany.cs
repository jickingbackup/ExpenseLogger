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

namespace ExpenseLoggerWinApp
{
    public partial class FormCompany : Form,ICompanyView
    {
        CompanyPresenter presenter;

        public FormCompany(int id =0)
        {
            InitializeComponent();
            presenter = new CompanyPresenter(this);

            if (id > 0)
            {
                presenter.Display(id);
            }
            else
            {
                this.Id =0;
                this.Text = "New Company";
                buttonDelete.Text = "Cancel";
                buttonSave.Text = "Save";
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            presenter.Save();
            //TODO:Add closure
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //TODO:Add closure And implement delete
            this.Close();
        }


        #region ICompanyView Members

        public int Id
        {
            get;
            set;
        }

        public string NameCompany
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

        public string Address
        {
            get
            {
                return textBoxAddress.Text.Trim();
            }
            set
            {
                textBoxAddress.Text = value;
            }
        }

        public int Tin
        {
            get
            {
                return Convert.ToInt32(textBoxTIN.Text.Trim());
            }
            set
            {
                textBoxTIN.Text = value.ToString();
            }
        }

        #endregion
    }
}
