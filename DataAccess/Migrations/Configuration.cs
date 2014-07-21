namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataAccess.EFModels;
    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.DAL.ExpenseLoggerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(DataAccess.DAL.ExpenseLoggerContext context)
        {
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Companies.AddOrUpdate(
                c => c.Id,
                new CompanyModel() { Id = 1,Name="NA",Address="NA, Philippines",Tin=10001}
                );
            context.Products.AddOrUpdate(
                p => p.Id,
                new ProductModel() { Id = 1,Name = "NA",Description ="NA",CompanyId = 1}
                );
            context.ExpenseRecord.AddOrUpdate(
                r => r.Id,
                new ExpenseRecordModel(){Id =1,Description = "Test Record.",Price= 0,ProductId=1,Date=DateTime.Now}
            );
        }
    }
}
