using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Models;
using DataAccess;
namespace Service
{
    public class Service : IService
    {
        static UnitOfWork uWork;

        #region IModel Members

        static Service()
        {
            uWork= new UnitOfWork();
        }

        public Company GetCompanyById(int id)
        {
            Company company = uWork.CompanyRepo.Get().Where(c => c.Id == id).SingleOrDefault();
            return company;
        }

        public IList<Company> GetAllCompany()
        {
            IList<Company> companies = uWork.CompanyRepo.Get().ToList();
            return companies;
        }

        public void AddCompany(Company company)
        {
            uWork.CompanyRepo.Insert(company);
            
        }

        public void UpdateCompany(Company company)
        {
            uWork.CompanyRepo.Update(company);
            
        }

        public void DeleteCompany(Company company)
        {
            uWork.CompanyRepo.Delete(company.Id);
            
        }

        public Product GetProductById(int id)
        {
            Product product = uWork.ProductRepo.GetByID(id);
            return product;
        }

        public IList<Product> GetAllProduct()
        {
            IList<Product> products = uWork.ProductRepo.Get().ToList();
            return products;
        }

        public void AddProduct(Product Product)
        {
            uWork.ProductRepo.Insert(Product);
            
        }

        public void UpdateProduct(Product Product)
        {
            uWork.ProductRepo.Update(Product);
            
        }

        public void DeleteProduct(Product Product)
        {
            uWork.ProductRepo.Delete(Product.Id);
            
        }

        public ExpenseRecord GetExpenseRecordById(int id)
        {
            ExpenseRecord record = uWork.ExpenseRecordRepo.GetByID(id);
            return record;
        }

        public IList<ExpenseRecord> GetAllExpenseRecord()
        {
            IList<ExpenseRecord> records = uWork.ExpenseRecordRepo.Get().ToList();
            return records;
        }

        public void AddExpenseRecord(ExpenseRecord record)
        {
            uWork.ExpenseRecordRepo.Insert(record);
            
        }

        public void UpdateExpenseRecord(ExpenseRecord record)
        {
            uWork.ExpenseRecordRepo.Update(record);
            
        }

        public void DeleteExpenseRecord(ExpenseRecord record)
        {
            uWork.ExpenseRecordRepo.Delete(record.Id);
            
        }

        #endregion

        public void Save()
        {
            uWork.Save();
        }

    }
}
