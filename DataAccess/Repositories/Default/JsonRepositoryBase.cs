using System;
using System.Collections.Generic;
using DataAccess.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;
using DataAccess.Common.Attributes;
using DataAccess.DataContext.Default;

namespace DataAccess.Repositories.Default
{
    public class JsonRepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly JsonDataContext _dataContext;
        public JsonRepositoryBase(JsonDataContextFactory<T> jsonDataContextFactory)
        {
            _dataContext = jsonDataContextFactory.Create();
        }

        public virtual T Create(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            ValidateEntity(entity);
            _dataContext.Items.Value.Add(JToken.Parse(JsonConvert.SerializeObject(entity, Formatting.Indented)));
            _dataContext.SaveChanges();

            return entity;
        }

        public virtual T GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            JObject dataEntity = _dataContext.Items.Value
                .Children<JObject>()
                .FirstOrDefault(x => x["Id"].ToString() == id);

            return dataEntity == null ? null : dataEntity.ToObject<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dataContext.Items.Value.ToObject<IEnumerable<T>>();
        }

        // Here could be another methods like Update, Delete etc. But they were skipped because of scope of the task

        #region Private methods

        private void ValidateEntity(T entity)
        {
            IEnumerable<string> uniqueProperties = GetUniqueProperties(entity);
            foreach (string property in uniqueProperties)
            {
                if (_dataContext.Items.Value.Children<JObject>().Any(x => x[property].ToString() == GetPropValue(entity, property).ToString())){
                    throw new ArgumentException(typeof(T).Name + " with such " + property + " has already exist!");
                }
            }
        }

        private IEnumerable<string> GetUniqueProperties(T entity)
        {
            List<string> uniqueProperties = new List<string>();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                IEnumerable<Attribute> customAttributes = prop.GetCustomAttributes(true);
                foreach (Attribute attr in customAttributes)
                {
                    if (attr is UniqueAttribute)
                    {
                        uniqueProperties.Add(prop.Name);
                    }
                }
            }
            return uniqueProperties;
        }

        private object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        #endregion
    }
}
