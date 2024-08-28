using System.Linq.Expressions;
using AwardProjectEntity.Base;

namespace AwardProjectDal
{
    public interface IBaseDal<TEntity> where TEntity : IBaseEntity
    {
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> GetAll(List<string> includes);

        public IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>> predicates);

        public IEnumerable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>?> predicates, List<string>? includes);

        public TEntity? GetById(int id);

        public TEntity? GetById(int id, List<string> include);

        public void Add(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);
    }

}
