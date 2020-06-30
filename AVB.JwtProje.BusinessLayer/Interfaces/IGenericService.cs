using AVB.JwtProje.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AVB.JwtProje.BusinessLayer.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        Task<List<TEntity>> GetAll();

        //Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetById(int id);

        //Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(TEntity entity);
    }
}