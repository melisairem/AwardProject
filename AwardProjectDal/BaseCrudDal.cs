using AwardProjectEntity.Base;

namespace AwardProjectDal
{
    public abstract class BaseCrudDal<TEntity> : IBaseDal<TEntity> where TEntity : BaseEntity
    {
        protected ModelContext _context => ModelContext.Intance;

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList(); 
        }

        public virtual TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            entity.AddDate = DateTime.Now;
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            TEntity? entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}