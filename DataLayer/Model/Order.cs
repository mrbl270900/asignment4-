using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; } = new DateTime();

        public DateTime? Required { get; set; } = new DateTime();

        public DateTime? Shipped { get; set; } = new DateTime();

        public int? Freight { get; set; }

        public string? ShipName { get; set; }

        public string? ShipCity { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
