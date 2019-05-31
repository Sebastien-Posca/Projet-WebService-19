using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary {

    [ServiceContract]
    public interface IService {

        [OperationContract]
        Task<Station[]> getStationsOfContract(string contract);

        [OperationContract]
       Task<Contract[]> getContracts();

        [OperationContract]
        Task<int> getAvailableBikesCountOfStation(string station, string contract);
    }

    [DataContract]
    public class Station
    {
        [DataMember]
        public readonly int number;

        [DataMember]
        public readonly string name;

        [DataMember]
        public readonly string contract_name;

        [DataMember]
        public readonly int available_bikes;

    }

    [DataContract]
    public class Contract
    {
        [DataMember]
        public readonly string name;

    }

}
