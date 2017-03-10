using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DataAccess.DataContext.Default
{
    public class JsonDataContextFactory<T>
    {
        private readonly string _dataFilePath;
        public JsonDataContextFactory()
        {
            _dataFilePath = Path.Combine(
                Directory.GetParent(new ApplicationEnvironment().ApplicationBasePath).ToString(),
                "data",
                typeof(T).Name + ".json"
            );
        }

        public virtual JsonDataContext Create()
        {
            if (!File.Exists(_dataFilePath))
            {
                string dataFolderPath = Directory.GetParent(_dataFilePath).ToString();
                if (!Directory.Exists(dataFolderPath))
                {
                    Directory.CreateDirectory(dataFolderPath);
                }

                File.Create(_dataFilePath).Dispose();
            }
            Lazy<JArray> dataStorage = new Lazy<JArray>(() => new FileInfo(_dataFilePath).Length == 0 ?
                new JArray() : JArray.Parse(File.ReadAllText(_dataFilePath)));

            return new JsonDataContext(_dataFilePath, dataStorage);
        }
    }
}
