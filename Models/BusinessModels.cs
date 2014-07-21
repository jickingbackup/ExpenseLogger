using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Company
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Tin { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }


    public class Product
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public Company Company{ get; set; }
        public virtual ICollection<ExpenseRecord> ExpenseRecords { get; set; } 
    }

    public class ExpenseRecord
    {


        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product{ get; set; }
    }

}
