using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.BusinessLayer.Interfaces;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Interfaces;

namespace AVB.JwtProje.BusinessLayer.Concretes
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable,new()
    {
        private readonly IGenericDal<TEntity> _genericDal;

        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }


        public async Task<List<TEntity>> GetAll()
        {
            return await _genericDal.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _genericDal.GetById(id);
        }

        public async Task Add(TEntity entity)
        {
            await _genericDal.Add(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _genericDal.Update(entity);
        }

        public async Task Remove(TEntity entity)
        {
            await _genericDal.Remove(entity);
        }
    }
}
