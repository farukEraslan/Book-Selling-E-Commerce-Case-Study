using BookSeller.Core.DataAccess.Abstract;
using BookSeller.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller.DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {

    }
}
