using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookSeller.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(Expression<Func<T, bool>> expression);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
    }
}
