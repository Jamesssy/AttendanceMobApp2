using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AttendanceMobApp2.Data
{
    public class GenericFileRepository<T> where T : IEntity
    {
        private string fileName;

        public GenericFileRepository(string filename)
        {
            this.fileName = filename;
        }

        public T Get(int id)
        {
            var items = LoadEntities();
            return items.FirstOrDefault(i => i.Id == id);
        }

        
        public IEnumerable<T> GetAll()
        {
            return LoadEntities();
        }

        private IEnumerable<T> LoadEntities()
        {
            var savedJson = DependencyService.Get<IFile>().LoadText(fileName);
            var deserializedTrayItems = JsonConvert.DeserializeObject<IEnumerable<T>>(savedJson);
            return deserializedTrayItems;
        }

        public void Save(T entity)
        {
            List<T> items;
            if (DependencyService.Get<IFile>().FileExists(fileName))
            {
                items = LoadEntities().ToList();
                var item = items.FirstOrDefault(i => i.Id == entity.Id);
                if (item != null)
                {
                    items.Remove(item);
                }
            }
            else
            {
                items = new List<T>();
            }
            items.Add(entity);
            StoreEntities(items);

        }

        public void Save(IEnumerable<T> entities)
        {
            StoreEntities(entities);
        }

        private void StoreEntities(IEnumerable<T> entities)
        {
            var serializedEntities = JsonConvert.SerializeObject(entities);
            DependencyService.Get<IFile>().SaveText(fileName, serializedEntities);
        }

        public void Delete(int id)
        {
            var items = LoadEntities().ToList();
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                items.Remove(item);
            }

            StoreEntities(items);
        }


    }
}
