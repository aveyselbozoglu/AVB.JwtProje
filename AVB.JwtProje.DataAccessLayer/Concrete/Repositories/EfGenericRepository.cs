using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AVB.JwtProje.DataAccessLayer.Concrete.EntityFrameworkCore;
using AVB.JwtProje.DataAccessLayer.Interfaces;
using AVB.JwtProje.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AVB.JwtProje.DataAccessLayer.Concrete.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity:class,ITable,new()
    {
        public async Task<List<TEntity>> GetAll()
        {
            await using var context = new DatabaseContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new DatabaseContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            await using var context = new  DatabaseContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            await using var context = new DatabaseContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task Add(TEntity entity)
        {
            await using var context = new DatabaseContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            await using var context = new DatabaseContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            await using var context = new DatabaseContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
