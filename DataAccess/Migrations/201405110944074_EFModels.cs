namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EFModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "Company");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.ExpenseRecords", newName: "ExpenseRecord");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ExpenseRecord", newName: "ExpenseRecords");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Company", newName: "Companies");
        }
    }
}
