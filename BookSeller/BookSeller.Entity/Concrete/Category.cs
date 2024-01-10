using BookSeller.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller.Entity.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Products Navi Prop
        public List<Product> Products { get; set; }
    }
}
