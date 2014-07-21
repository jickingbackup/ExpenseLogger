using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.EFModels
{
    [Table("Company")]
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Tin { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }

    [Table("Product")]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyModel Company { get; set; }

        public virtual ICollection<ExpenseRecordModel> ExpenseRecords { get; set; }
    }

    [Table("ExpenseRecord")]
    public class ExpenseRecordModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductModel Product { get; set; }
    }
}
