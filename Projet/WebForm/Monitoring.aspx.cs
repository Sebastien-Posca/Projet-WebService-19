using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Monitoring : System.Web.UI.Page
    {
        MonitoringRef.MonitoringServiceClient client = new MonitoringRef.MonitoringServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";

            Label1.Text = "" + client.numberOfRequest("getStationsOfContract");
            String city = client.mostPopularCity();
            mostPopularCity.Text = client.mostPopularCity() + " (" + client.cityPopularity(city) + ")";
            Label3.Text = client.avgTimeRequest("getStationsOfContract") + " ms";
            this.orderCities(client.cities());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = "" + client.numberOfRequest("getStationsOfContract");
            String city = client.mostPopularCity();
            mostPopularCity.Text = client.mostPopularCity() + " (" + client.cityPopularity(city) + ")";
            Label3.Text = client.avgTimeRequest("getStationsOfContract") + " ms";
            this.orderCities(client.cities());
        }


        protected void orderCities(Dictionary<String, int> cities)
        {
            int top = 0;
            var names = cities.OrderBy(d => d.Value).ToList();
            if (names.Count() > 3)
            {
                top = 3;
            }
            else top = names.Count();
        for(int i = 0; i<top ; i++)
            {
                Chart1.Series["Series"+i].Points.AddXY(i+1, names[i].Value);
                if(i == 0)
                {
                    Label4.Text = "1 - " + names[0].Key;

                }
                else if (i == 1)
                {
                    Label5.Text = "2 - " + names[1].Key;

                }
                if (i == 2)
                {
                    Label6.Text = "3 - " + names[2].Key;

                }
            }
        }
    
    }
}