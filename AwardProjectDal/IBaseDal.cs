using AwardProjectEntity.Base;

namespace AwardProjectDal
{
    public interface IBaseDal<TEntity> where TEntity : IBaseEntity
    {
        public IEnumerable<TEntity> GetAll();

        public TEntity GetById(int id);

        public void Add(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);
    }

}
