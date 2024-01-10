namespace BookSeller.Core.DataAccess.Concrete.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            TContext context = new TContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            TContext context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            TContext context = new TContext();
            var removedEntity = context.Entry(entity);
            removedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            TContext context = new TContext();
            return context.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            TContext context = new TContext();
            return context.Set<TEntity>().Where(expression).ToList();
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> expression)
        {
            TContext context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(expression);
        }
    }
}
