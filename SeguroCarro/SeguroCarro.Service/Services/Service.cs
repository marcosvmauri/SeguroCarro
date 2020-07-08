using SeguroCarro.Repository;
using SeguroCarro.Service.Interfaces;
using System.Collections.Generic;

namespace SeguroCarro.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> Get(List<string> relations)
        {
            return _repository.Get(relations);
        }

    }
}
