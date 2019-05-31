using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace WcfServiceLibrary.Cache
{
    class Cache
    {

        private ObjectCache cache = MemoryCache.Default;

        private CachePolicy currentPolicy;

        public Cache(CachePolicy cachePolicy)
        {
            this.currentPolicy = cachePolicy;

        }

        public void setPolicy(CachePolicy cachePolicy)
        {
            this.currentPolicy = cachePolicy;
        }

        public void add(string key, object obj)
        {
            string[] splittedKey = key.Split(']');
            string keyPrefix = splittedKey[0] + ']';
            CacheItemPolicy policy = this.currentPolicy.getPolicy(keyPrefix);
            this.cache.Add(key, obj, policy);
        }

        public object this[string key] {
            get {
                return this.cache[key];
            }
        }
        public object get(string key)
        {
            return this.cache.Get(key);
        }

        public bool contains(string key)
        {
            return this.cache.Contains(key);
        }
    }
}
