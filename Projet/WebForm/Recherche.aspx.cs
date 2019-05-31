using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Routing;
using System.Threading.Tasks;

namespace WebForm
{


    public partial class Recherche : System.Web.UI.Page
    {

        private ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void SearchAsync(object Sender, EventArgs e)
        {

            List.Rows = 20;
            emptyList();

            city.Attributes.Remove("style");

            if (city.Text.Length != 0)
            {
                if(stationNumber.Text.Length != 0)
                {
                    bool success = await this.TryToSearchStationAsync();
                    if (!success) {
                        success = await TryToListStations("");
                        if (!success)
                        {
                            info.Text = "Nom de ville incorrect";
                            city.Attributes.Add("style", "border: 1px solid red !important;");
                        } else
                        {
                            info.Text = "Numéro de station incorrect, liste des stations de " + city.Text;
                        }
                    }


                }
                else  if(stationName.Text.Length != 0)
                {
                    await this.TryToListStations(stationName.Text);
                }
                else 
                {
                    bool success = await this.TryToListStations("");
                    if (!success)
                        SearchContractsAsync();
                }
                

            } else
            {

                info.Text = "Indiquez un nom de ville";
                city.Attributes.Add("style", "border: 1px solid red !important;");
            }


        }

        private async void SearchContractsAsync()
        {
            info.Text = "Recherche de villes ayant " + city.Text + " dans leur nom";
            var myTask = Task.Run(() => client.getContracts().ToList());
            List<ServiceReference1.Contract> contracts = await myTask;

            contracts.ForEach(delegate (ServiceReference1.Contract contract)
            {
                if(contract.name.Contains(city.Text.ToLower()))
                    List.Items.Add(contract.name.First().ToString().ToUpper() + contract.name.Substring(1));
            });
        }
        protected async void List_SelectedIndexChangedAsync(object sender, EventArgs e)
        {

            if (! (List.Items.Count > 0 && List.Items[0].Text.Contains("vélo(s)")))
            {
                string contract = List.SelectedItem.ToString();
                city.Text = contract;
                emptyList();
                await this.TryToListStations("");

            }

        }
   

        private async Task<bool> TryToListStations(string filterString)
        {
            var myTask = Task.Run(() => client.getStationsOfContract(city.Text));
            ServiceReference1.Station[] stations = await myTask;
            if (stations != null)
            {
                info.Text = "" + stations.Length + " stations";


                for (int i = 0; i < stations.Length; i++)
                {
                    if (stations[i].name.Contains(filterString))
                        List.Items.Add(stations[i].name + ": "+ stations[i].available_bikes + " vélo(s) disponible(s)");

                }

                return true;
            }
            else
            {
                return false;
            }

        }

        private async Task<bool> TryToSearchStationAsync()
        {
            if(stationNumber.Text.Length != 0)
            {
                var myTask = Task.Run(() => client.getAvailableBikesCountOfStation(stationNumber.Text, city.Text));
                int availableBikes = await myTask;
                if(availableBikes >= 0)
                {
                    info.Text = "station trouvée";
                    List.Items.Add(stationNumber.Text  + ": " + availableBikes + " vélo(s) disponibles");
                    return true;
                }
            }
            return false;

        }

        private void emptyList()
        {
            List.Items.Clear();

        }


        protected void stationNumber_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
