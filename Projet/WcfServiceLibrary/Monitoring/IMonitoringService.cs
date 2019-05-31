using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace WcfServiceLibrary
{


    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IMonitoringService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IMonitoringService
    {

        [OperationContract]
        int numberOfRequest(String name);

        [OperationContract]
        int avgTimeRequest(String name);

        [OperationContract]
        int cityPopularity(String name);

        [OperationContract]
        String mostPopularCity();

        [OperationContract]
        Dictionary<String, int> cities();

    }
}
