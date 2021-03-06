﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementReactWebAPI.Interfaces.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);

        TEntity FindById(int id);

        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void Remove(TEntity item);

        void Update(TEntity item);
    }
}
