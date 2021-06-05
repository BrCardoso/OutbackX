using OutbackX.Mobile.Models;
using PCLExt.FileStorage.Folders;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutbackX.Mobile.Services
{
    public class SqLiteDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        public SQLiteConnection cnn;
        public SqLiteDataStore()
        {
            var folder = new LocalRootFolder();
            var file = folder.CreateFile("appOutbackX", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            cnn = new SQLiteConnection(file.Path);
            cnn.CreateTable<Item>();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            return await Task.FromResult(cnn.Insert(item) == 1);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            return await Task.FromResult(cnn.Update(item) == 1);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            return await Task.FromResult(cnn.Delete(item) == 1);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(cnn.Get<Item>(id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(cnn.Table<Item>().ToList());
        }
    }
}