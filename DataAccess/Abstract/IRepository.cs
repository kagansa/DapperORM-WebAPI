using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();

        TEntity GetById(int entityId);

        int Add(TEntity entity);

        int Remove(int entityId);

        int  Update(TEntity entity);
    }
}