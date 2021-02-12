using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Dev.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dev.Datas.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DevDbContext Db;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(DevDbContext db)
        {
            Db = db;
            dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetForId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Add(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }


        public virtual async Task Delete(Guid id)
        {
            
            //dbSet.Remove(await dbSet.FindAsync(id));
            dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        
        public async void Dispose()
        {
            Db?.Dispose();
        }
    }
}
