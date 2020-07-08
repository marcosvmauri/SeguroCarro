using System.Collections.Generic;

namespace SeguroCarro.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(List<string> relations);
    }
}
