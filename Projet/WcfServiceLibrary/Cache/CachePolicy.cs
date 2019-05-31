using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace WcfServiceLibrary.Cache
{
    class CachePolicy
    {

        private Dictionary<string, long> keyPrefixToCachingTimeSeconds = new Dictionary<string, long>();

        public CachePolicy(Dictionary<string, long> keyPrefixToCachingTimeSeconds)
        {
            this.keyPrefixToCachingTimeSeconds = keyPrefixToCachingTimeSeconds;
        }

        public CacheItemPolicy getPolicy(string keyPrefix)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(keyPrefixToCachingTimeSeconds[keyPrefix]);
            return policy;
        }

    }
}
