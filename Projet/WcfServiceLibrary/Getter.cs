using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using WcfServiceLibrary.Cache;

namespace WcfServiceLibrary
{
    class Getter
    {

        Cache.Cache cache = new Cache.Cache(cachePoliciesDict["DEFAULT"]);

        public async Task<T> getDeserializedJSON<T> (string key, WebRequest request, bool putInCache = true) where T: class
        {
            T obj = this.cache[key] as T;

            if (obj == null)
            {
                try
                {
                    WebResponse response = await request.GetResponseAsync();
                    Stream dataStream = response.GetResponseStream(); // Open the stream using a StreamReader for easy access. 
                    StreamReader reader = new StreamReader(dataStream); // Read the content. 
                    string responseFromServer = reader.ReadToEnd(); // Display the content.
                    obj = JsonConvert.DeserializeObject<T>(responseFromServer);

                    if (putInCache)
                        this.cache.add(key, obj);
                }
                catch (WebException e)
                {
                    return default(T);
                }
   
            }


            return obj;
        }

        /*** STATIC ***/

        public static string CITIES_KEY_PREFIX = "[cities]";
        public static string STATIONS_KEY_PREFIX = "[stations of city]";
        public static string AVAILABLE_BIKES_KEY_PREFIX = "[available bikes of station]";

        private static Dictionary<string, CachePolicy> cachePoliciesDict;

        static Getter()
        {
            cachePoliciesDict = new Dictionary<string, CachePolicy>()
            {
                {"REAL_TIME",
                    new CachePolicy(new Dictionary<string, long> {
                            { CITIES_KEY_PREFIX, 1000},
                            { STATIONS_KEY_PREFIX, 100},
                            { AVAILABLE_BIKES_KEY_PREFIX, 10},
                        }
                    )
                },

                {"DEFAULT",
                    new CachePolicy(new Dictionary<string, long> {
                            { CITIES_KEY_PREFIX, 10000},
                            { STATIONS_KEY_PREFIX, 1000},
                            { AVAILABLE_BIKES_KEY_PREFIX, 100},
                        }
                    )
                },
            };
        }

    }
}
