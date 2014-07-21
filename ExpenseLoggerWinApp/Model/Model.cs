using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using Service;
namespace ExpenseLoggerWinApp.Model
{
    public class Model:IModel
    {
        static IService service = new Service.Service();

        #region IModel Members

        public Company GetCompanyById(int id)
        {
            Company company = service.GetCompanyById(id);
            return company;
        }

        public IList<Company> GetAllCompany()
        {
            IList<Company> companies = service.GetAllCompany();
            return companies;
        }

        public void AddCompany(Company company)
        {
            service.AddCompany(company);
            service.Save();
        }

        public void UpdateCompany(Company company)
        {
            service.UpdateCompany(company);
            service.Save();
        }

        public void DeleteCompany(Company company)
        {
            service.DeleteCompany(company);
            service.Save();
        }

        public Product GetProductById(int id)
        {
            Product product = service.GetProductById(id);
            return product;
        }

        public IList<Product> GetAllProduct()
        {
            IList<Product> products = service.GetAllProduct();
            return products;
        }

        public void AddProduct(Product Product)
        {
            service.AddProduct(Product);
            service.Save();
        }

        public void UpdateProduct(Product Product)
        {
            service.UpdateProduct(Product);
            service.Save();
        }

        public void DeleteProduct(Product Product)
        {
            service.DeleteProduct(Product);
            service.Save();
        }

        public ExpenseRecord GetExpenseRecordById(int id)
        {
            ExpenseRecord record = service.GetExpenseRecordById(id);
            return record;
        }

        public IList<ExpenseRecord> GetAllExpenseRecord()
        {
            IList<ExpenseRecord> records = service.GetAllExpenseRecord();
            return records;
        }

        public void AddExpenseRecord(ExpenseRecord record)
        {
            service.AddExpenseRecord(record);
            service.Save();
        }

        public void UpdateExpenseRecord(ExpenseRecord record)
        {
            service.UpdateExpenseRecord(record);
            service.Save();
        }

        public void DeleteExpenseRecord(ExpenseRecord record)
        {
            service.DeleteExpenseRecord(record);
            service.Save();
        }

        #endregion
    }
}
