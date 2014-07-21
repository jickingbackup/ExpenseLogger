using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.EFModels;
namespace DataAccess.DAL
{
    public class ExpenseLoggerContext:DbContext
    {
        #region DBSets

        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ExpenseRecordModel> ExpenseRecord { get; set; }

        #endregion

        public ExpenseLoggerContext()
            : base("ExpenseLoggerDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Disables pluralizing convention
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Disables Lazy loading.
            this.Configuration.LazyLoadingEnabled = false;

            //base.OnModelCreating(modelBuilder);
        }
    }
}
