using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DataAccess.DataContext.Default
{
    public class JsonDataContext
    {
        protected readonly string _dataFilePath;

        public JsonDataContext(string dataFilePath, Lazy<JArray> dataStorage)
        {
            _dataFilePath = dataFilePath;
            Items = dataStorage;
        }

        public Lazy<JArray> Items { get; }

        public virtual void SaveChanges()
        {
            File.WriteAllText(_dataFilePath, Items.ToString());
        }
    }
}
