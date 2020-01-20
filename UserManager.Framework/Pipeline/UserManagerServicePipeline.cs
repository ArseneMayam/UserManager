using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Framework.Pipeline
{
    public class UserManagerServicePipeline : IUserManagerServicePipeline
    {
        private IMemoryCache Cache { get; set; }
        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; set; }

        public UserManagerServicePipeline(IMemoryCache cache)
        {
            Cache = cache;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions();
        }

        // TryGetCache
        // vérifie si la donnée existe deja en cache
        protected bool TryGetCache(string nomCache)
        {
            object result;
            return Cache.TryGetValue<object>(nomCache, out result);
        }
        // StoreDataCache
        // Utiliser pour inserer du data dans le cache
        protected void StoreDataCache(string nomCache, object data)
        {
            Cache.Set<object>(nomCache, data, MemoryCacheEntryOptions);
        }
        // RetrieveDataCache
        // Utiliser pour recuperer du data contenu dans le cache
        protected object RetrieveDataCache(string nomCache)
        {
            return Cache.Get<object>(nomCache);
        }

        public bool TestTryGetCache(string nomCache)
        {
            return TryGetCache(nomCache);
        }

        public void TestStoreDataCache(string nomCache, object data)
        {
            StoreDataCache(nomCache, data);
        }

        public object TestRetrieveDataCache(string nomCache)
        {
            return RetrieveDataCache(nomCache);
        }

    }
}
