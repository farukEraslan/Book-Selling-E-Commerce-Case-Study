using BookSeller.Core.DataAccess.Concrete.EntityFramework;
using BookSeller.DataAccess.Abstract;
using BookSeller.DataAccess.Concrete.EntityFramework.Contexts;
using BookSeller.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller.DataAccess.Concrete.EntityFramework
{
    public class EFProductDAL : EFRepositoryBase<Product, BookSellerDbContext>, IProductDAL
    {

    }
}
