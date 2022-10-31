using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public string? QuantityPerUnit { get; set; }

        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderDetails>? OrderDetails { get; set; }

        [NotMapped]
        public string? CategoryName { get; set; }
        [NotMapped]
        public string? ProductName { get; set; }
    }
}
