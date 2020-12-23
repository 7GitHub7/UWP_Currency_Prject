using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HttpAsynchronous
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        private int counter;
        private string result;

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage2));
        }


        public class Currency
        {
            [JsonProperty(PropertyName = "table")]
            public string table { get; set; }

            [JsonProperty(PropertyName = "no")]
            public string no { get; set; }

            [JsonProperty(PropertyName = "effectiveDate")]
            public string effectiveDate { get; set; }

            [JsonProperty(PropertyName = "rates")]
            public List<NastedRates> rates { get; set; }
        }

        private List<Currency> CurrencyObjectsList = new List<Currency>();
        private List<NastedRates> nastedRates = new List<NastedRates>();

        public class NastedRates
        {
            [JsonProperty(PropertyName = "currency")]
            public string currency { get; set; }

            [JsonProperty(PropertyName = "code")]
            public string code { get; set; }

            [JsonProperty(PropertyName = "mid")]
            public double mid { get; set; }

            private int factor;
            public int Factor { get { return factor; } set { factor = value; } }
        }

        private void button_ClickAsync(object sender, RoutedEventArgs e)
        {
            httpRequest();
        }

        private async System.Threading.Tasks.Task httpRequest()

        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("http://api.nbp.pl/api/exchangerates/tables/A/2020-03-01/2020-04-01/");
            using (WebResponse myResponse = await myRequest.GetResponseAsync())
            {
                using (StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                    CurrencyObjectsList = JsonConvert.DeserializeObject<List<Currency>>(result);
                    CurrencyDateList.ItemsSource = CurrencyObjectsList;
                    CurrencyDateList.DisplayMemberPath = "effectiveDate";
                }
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = 0;
            index = CurrencyDateList.SelectedIndex;
            addFactor(index);
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = CurrencyListView.SelectedIndex;
            Tb_factor.Text = Convert.ToString(nastedRates[index].Factor);
            Tb_mid.Text = Convert.ToString(nastedRates[index].mid);
        }

        private async System.Threading.Tasks.Task addFactor(int index)
        {
            foreach (Currency item in CurrencyObjectsList)
            {
                foreach (NastedRates nastedRate in item.rates)
                {
                    if (nastedRate.mid < 0.1)
                    { nastedRate.Factor = 100; }
                    else nastedRate.Factor = 1;
                    Console.WriteLine(nastedRate.code);
                }
            }
            nastedRates = CurrencyObjectsList[index].rates;
            CurrencyListView.ItemsSource = nastedRates;
        }
    }
}