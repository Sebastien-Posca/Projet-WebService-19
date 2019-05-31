using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "MonitoringService" à la fois dans le code et le fichier de configuration.
    public class MonitoringService : IMonitoringService
    {
        public int avgTimeRequest(string name)
        {
            if (Monitoring.requestTime.ContainsKey(name))
            {
                int size = Monitoring.requestTime[name].Count();
                int sum = Monitoring.requestTime[name].Sum();
                return sum/size;
            }
            else
            {
                return 0;
            }
        }

        public Dictionary<string, int> cities()
        {
            return Monitoring.popularCity;
        }

        public int cityPopularity(string name)
        {
            if (Monitoring.popularCity.ContainsKey(name))
            {
                return Monitoring.popularCity[name];
            }
            else
            {
                return -1;
            }
        }



        public String mostPopularCity()
        {
            if (Monitoring.popularCity.Count != 0)
            {
                return Monitoring.popularCity.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            }
            else
            {
                return "Pas assez de données";
            }
        }

        int IMonitoringService.numberOfRequest(String name)
        {
            if (Monitoring.requestNumber.ContainsKey(name))
            {
                return Monitoring.requestNumber[name];
            }
            else
            {
                return 0;
            }
        }

    }
 }
