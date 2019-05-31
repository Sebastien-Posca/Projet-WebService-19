using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Timers;
using System.Diagnostics;

namespace WcfServiceLibrary
{
    public class Service : IService
    {
        private string API_KEY_VAR = "apiKey=a520ce56ec3e70556cc1ca66a3eafcbf462c79c4";
        private Getter getter = new Getter();
        private Timer _timer = new Timer();


        public async Task<Station[]> getStationsOfContract(string contract)
        {
            Monitoring.AddPopularCity(contract);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Monitoring.AddRequest("getStationsOfContract");
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&" + API_KEY_VAR);
            Station[] stations = await getter.getDeserializedJSON<Station[]>(Getter.STATIONS_KEY_PREFIX + contract, request);
            Monitoring.AddRequestTime("getStationsOfContract", (int)stopwatch.ElapsedMilliseconds);
            return stations;
        }

        public async Task<Contract[]> getContracts()
        {
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?"+ API_KEY_VAR);
            Contract[] contracts = await getter.getDeserializedJSON<Contract[]>(Getter.CITIES_KEY_PREFIX, request);
            return contracts;
        }

        public async Task<int> getAvailableBikesCountOfStation(string station, string contract)
        {
            Monitoring.AddPopularCity(contract);
            WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations/" + station + "?contract=" + contract + "&" + API_KEY_VAR);
            Station _station = await getter.getDeserializedJSON<Station>(Getter.AVAILABLE_BIKES_KEY_PREFIX+contract+station, request);
            if (_station == null) return -1;
            return _station.available_bikes;
        }

    }
}
