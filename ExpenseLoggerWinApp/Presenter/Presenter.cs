using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseLoggerWinApp.Model;
using ExpenseLoggerWinApp.View;

using Models;
using DataAccess;
namespace ExpenseLoggerWinApp.Presenter
{
    /// <summary>
    /// Base class for all presenter classes. Keeps track of Model and View classes.
    /// Notice that Model is static and View is set in the constructor.
    /// </summary>
    /// <remarks>
    /// MV Patterns: MVP design pattern.
    /// </remarks>
    /// <typeparam name="T">Type of view.</typeparam>
    public abstract class Presenter<T>:IPresenter where T : IView
    {
        protected static IModel Model { get; private set; }
        //static CTor for model
        static Presenter()
        {
            Model = new Model.Model();
        }
        //IOC Ctor
        public Presenter(T view)
        {
            View = view;
        }

        protected T View { get; private set; }

        public abstract void Display(int id =0);
    }

    public interface IPresenter
    {
        void Display(int id =0);
    }

    public class CompanyPresenter : Presenter<ICompanyView>
    {
        public CompanyPresenter(ICompanyView view)
            :base(view)
        {
        }

        public override void Display(int id = 0)
        {
            if (id <= 0) return;

            var company = Model.GetCompanyById(id);

            View.Id = company.Id;
            View.NameCompany = company.Name;
            View.Address = company.Address;
            View.Tin = company.Tin;

        }

        public void Save()
        {
            var company = new Company()
            {
                Id = View.Id,
                Name = View.NameCompany,
                Address = View.Address,
                Tin = View.Tin
            };

            if (company.Id > 0)
            {
                Model.UpdateCompany(company);
            }
            else
            {
                Model.AddCompany(company);
            }
        }

    }

    public class CompaniesPresenter : Presenter<ICompaniesView>
    {
        public CompaniesPresenter(ICompaniesView view)
            :base(view)
        {
        }

        public override void Display(int id =0)
        {
            View.Companies = Model.GetAllCompany();
        }
    }

    public class ProductPresenter : Presenter<IProductView>
    {
        public ProductPresenter(IProductView view)
            :base(view)
        {
        }

        public override void Display(int id=0)
        {
            if (id <= 0) return;

            var product = Model.GetProductById(id);
            View.Id = product.Id;
            View.ProductName = product.Name;
            View.CompanyId = product.CompanyId;
            View.Description = product.Description;
        }

        public void Save()
        {
            var product = new Product()
            {
                Id = View.Id,
                Name = View.ProductName,
                Description = View.Description,
                CompanyId = View.CompanyId
            };
            if (product.Id > 0)
            {
                Model.UpdateProduct(product);
            }
            else
            {
                Model.AddProduct(product);
            }
        }
    }

    public class ProductsPresenter : Presenter<IProductsView>
    {
        public ProductsPresenter(IProductsView view)
            :base(view)
        {
        }

        public override void Display(int id =0)
        {
            View.Products = Model.GetAllProduct();
        }
    }

    public class ExpenseRecordPresenter : Presenter<IExpenseRecordView>
    {
        public ExpenseRecordPresenter(IExpenseRecordView view)
            :base(view)
        {
        }

        public override void Display(int id=0)
        {
            if(id <= 0) return;

            var record = Model.GetExpenseRecordById(id);
            View.Id = record.Id;
            View.Amount = record.Price;
            View.Date = record.Date;
            View.Description = record.Description;
            View.ProductId = record.ProductId;
        }

        public void Save()
        {
            var record = new ExpenseRecord()
            {
                Id = View.Id,
                Date =View.Date,
                Description = View.Description,
                Price = View.Amount,
                ProductId = View.ProductId
            };

            if (record.Id > 0)
            {
                Model.UpdateExpenseRecord(record);
            }
            else
            {
                Model.AddExpenseRecord(record);
            }
        }
    }

    public class ExpenseRecordsPresenter : Presenter<IExpenseRecordsView>
    {
        public ExpenseRecordsPresenter(IExpenseRecordsView view)
            :base(view)
        {
        }

        public override void Display(int id =0)
        {
            View.ExpenseRecords = Model.GetAllExpenseRecord();
        }
    }
}
