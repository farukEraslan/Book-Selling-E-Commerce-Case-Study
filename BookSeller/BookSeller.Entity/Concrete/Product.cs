using BookSeller.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller.Entity.Concrete
{
    public class Product : IEntity
    {
        public Guid ProductId { get; set; }
        // Category FK
        public Guid CategoryId { get; set; }

        // Category Navi Prop
        public Category Category { get; set; }
        public string BookName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string ISBN { get; set; }
    }
}
