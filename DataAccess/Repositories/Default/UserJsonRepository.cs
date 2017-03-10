using System;
using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.Repositories.Common;
using Newtonsoft.Json.Linq;
using System.Linq;
using LinqKit;
using DataAccess.DataContext.Default;

namespace DataAccess.Repositories.Default
{
    public class UserJsonRepository : JsonRepositoryBase<User>, IUserRepository
    {
        public UserJsonRepository(JsonDataContextFactory<User> jsonDataContextFactory):base(jsonDataContextFactory)
        {
        }

        public IEnumerable<User> GetBy(UserFilterModel filterModel)
        {
            if (filterModel == null)
            {
                throw new ArgumentNullException(nameof(filterModel));
            }

            ExpressionStarter<JToken> filterBuilder = PredicateBuilder.New<JToken>();

            if (!string.IsNullOrEmpty(filterModel.Id))
            {
                filterBuilder.And(x => x["Id"].ToString() == filterModel.Id);
            }

            if (!string.IsNullOrEmpty(filterModel.Email))
            {
                filterBuilder.And(x => x["Email"].ToString() == filterModel.Email);
            }

            if (filterModel.ToDate.HasValue)
            {
                filterBuilder.And(x => x["Birthday"].Value<DateTime>() <= filterModel.ToDate.Value);
            }

            IEnumerable<User> dataEntities = _dataContext.Items.Value
                .Where(filterBuilder)
                .Select(x => x.ToObject<User>());

            return dataEntities ?? Enumerable.Empty<User>();
        }
    }
}
