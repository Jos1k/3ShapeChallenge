using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
}
