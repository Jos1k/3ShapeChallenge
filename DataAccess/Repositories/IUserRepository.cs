using DataAccess.Models;
using DataAccess.Repositories.Common;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        IEnumerable<User> GetBy(UserFilterModel filterModel);
    }
}
