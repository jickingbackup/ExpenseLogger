using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DAL;
using DataAccess.EFModels;
using Models;

namespace DataAccess
{

    /// <summary>
    /// Abstracts access to db.
    /// </summary>
    public class UnitOfWork
    {
        private static ExpenseLoggerContext _context;

        private IRepository<Product> _productRepo;
        private IRepository<Company> _companyRepo;
        private IRepository<ExpenseRecord> _expenseRecordRepo;

        public IRepository<Product> ProductRepo
        {
            get
            {
                if (_productRepo == null)
                {
                    _productRepo = new ProductRepository(_context);
                }
                return _productRepo;
            }
        }
        public IRepository<Company> CompanyRepo
        {
            get 
            {
                if (_companyRepo == null)
                {
                    _companyRepo = new CompanyRepository(_context);
                }
                return _companyRepo;
            }
        }
        public IRepository<ExpenseRecord> ExpenseRecordRepo
        {
            get
            {
                if (_expenseRecordRepo == null)
                {
                    _expenseRecordRepo = new ExpenseRecordRepository(_context);
                }
                return _expenseRecordRepo;
            }
        }

        public UnitOfWork()
            :this( new ExpenseLoggerContext())
        {
        }

        public UnitOfWork(ExpenseLoggerContext context)
        {
            _context = context;
            //_context.Configuration.AutoDetectChangesEnabled = false;

        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }




}
