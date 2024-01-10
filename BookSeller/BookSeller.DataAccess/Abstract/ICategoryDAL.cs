using BookSeller.Core.DataAccess.Abstract;
using BookSeller.Entity.Concrete;

namespace BookSeller.DataAccess.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {

    }
}
