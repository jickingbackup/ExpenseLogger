using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExpenseLoggerWinApp.Model
{
    using Models;
    using DataAccess;

    public interface IModel
    {
        #region Company
        Company GetCompanyById(int id);
        IList<Company> GetAllCompany();
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company); 
        #endregion

        #region Product
        Product GetProductById(int id);
        IList<Product> GetAllProduct();
        void AddProduct(Product Product);
        void UpdateProduct(Product Product);
        void DeleteProduct(Product Product);
        #endregion

        #region Product
        ExpenseRecord GetExpenseRecordById(int id);
        IList<ExpenseRecord> GetAllExpenseRecord();
        void AddExpenseRecord(ExpenseRecord record);
        void UpdateExpenseRecord(ExpenseRecord record);
        void DeleteExpenseRecord(ExpenseRecord record);
        #endregion

    }
}
