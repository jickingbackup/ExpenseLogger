using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ExpenseLoggerWinApp.View
{
    // marker interface, no members
    public interface IView
    {
    }

    /// respresents view of a list of members
    public interface ICompaniesView : IView
    {
        IList<Company> Companies { get; set; }
    }

    public interface ICompanyView : IView
    {
        int Id { get; set; }
        string NameCompany { get; set; }
        string Address { get; set; }
        int Tin { get; set; }
    }

    public interface IProductsView : IView
    {
        IList<Product> Products { get; set; }
    }

    public interface IProductView : IView
    {
        int Id { get; set; }
        string ProductName { get; set; }
        string Description { get; set; }
        int CompanyId { get; set; }
    }

    public interface IExpenseRecordsView : IView
    {
        IList<ExpenseRecord> ExpenseRecords { get; set; }
    }

    public interface IExpenseRecordView : IView
    {
        int Id { get; set; }
        string Description { get; set; }
        decimal Amount { get; set; }
        DateTime Date { get; set; }
        int ProductId { get; set; }
    }
}
