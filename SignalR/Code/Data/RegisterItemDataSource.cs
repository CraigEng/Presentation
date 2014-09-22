using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using BabyGiftRegisterLibrary.Model;
using BabyGiftRegisterLibrary.Default;

namespace Data
{
    public class RegisterItemDataSource
    {
        private const string CacheName = "cache";
        private IList<RegisterItem> _registerItems;

        public RegisterItemDataSource()
        {
            var cache = MemoryCache.Default;

            if (!cache.Contains(CacheName))
            {
                LoadData();
            }
            var cacheItem = cache.GetCacheItem(CacheName);

            if (cacheItem == null)
            {
                LoadData();
                return;
            }

            _registerItems = (IList<RegisterItem>) cacheItem.Value;
        }

        private void LoadData()
        {
            var cache = MemoryCache.Default;
            if (cache.Contains(CacheName))
            {
                return;
            }

            _registerItems = DataGenerator.GetInitialRegisterItems();

            var ci = new CacheItem(CacheName) {Value = _registerItems};
            var policy = new CacheItemPolicy {Priority = CacheItemPriority.Default};
            cache.Add(ci, policy);
        }

       

        public RegisterItem GetItem(int id)
        {
            return _registerItems.FirstOrDefault(x => x.Id == id);
        }

        public void SellItem(int id)
        {
            var item = _registerItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Sold = true;    
            }
        }

        public IEnumerable<RegisterItem> GetItemsInRegister()
        {
            return _registerItems.Where(x => x.InRegister).AsEnumerable();
        }

        public RegisterItem AddToRegister(string barCode)
        {
            var productId = Int32.Parse(barCode) - 1000000;
            var item = _registerItems.FirstOrDefault(x => x.Id == productId);
            if (item == null || item.InRegister)
            {
                return null;
            }
            item.InRegister = true;
            return item;
        }
    }
}