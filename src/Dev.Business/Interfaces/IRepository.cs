﻿using Dev.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{

    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetForId(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();

    }
}
