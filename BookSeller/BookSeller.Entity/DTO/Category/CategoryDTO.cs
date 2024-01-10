using BookSeller.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller.Entity.DTO.Category
{
    public class CategoryDTO : IDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
