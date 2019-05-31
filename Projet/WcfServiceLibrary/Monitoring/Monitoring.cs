using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{
    static class Monitoring
    {
        public static Dictionary<String, int> requestNumber = new Dictionary<String, int>();
        public static Dictionary<String, List<int>> requestTime = new Dictionary<String, List<int>>();
        public static Dictionary<String, int> popularCity = new Dictionary<string, int>();


        public static void AddRequest(String name)
        {
            if (requestNumber.ContainsKey(name))
            {
                requestNumber[name]++;
            }
            else
            {
                requestNumber.Add(name, 1);
            }
        }

        public static void AddRequestTime(String name, int time)
        {
            if (requestTime.ContainsKey(name))
            {
                requestTime[name].Add(time);
            }
            else
            {
                List<int> list= new List<int>();
                list.Add(time);
                requestTime.Add(name, list);
            }
        }

        public static void AddPopularCity(String name)
        {
            if (popularCity.ContainsKey(name))
            {
                popularCity[name]++;
            }
            else
            {
                popularCity.Add(name, 1);
            }
        }
    }
}
