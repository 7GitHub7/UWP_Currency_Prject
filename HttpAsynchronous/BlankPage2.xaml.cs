using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HttpAsynchronous
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
            this.InitializeComponent();
            LoadChartContents();



        }
        class Report
        {
            public string months { get; set; }
            public int countlent { get; set; }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = e.Parameter;

            // parameters.Name
            // parameters.Text
            // ...

            List<Report> lstSource = new List<Report>();
            lstSource.Add(new Report() { months = Convert.ToString(parameters), countlent = 10 });
            lstSource.Add(new Report() { months = "3", countlent = 20 });
            lstSource.Add(new Report() { months = "4", countlent = 10 });
            lstSource.Add(new Report() { months = "5", countlent = 13 });
            lstSource.Add(new Report() { months = "6", countlent = 18 });
            lstSource.Add(new Report() { months = "7", countlent = 33 });
            lstSource.Add(new Report() { months = "8", countlent = 41 });
            lstSource.Add(new Report() { months = "9", countlent = 31 });
            lstSource.Add(new Report() { months = "10", countlent = 21 });
            lstSource.Add(new Report() { months = "11", countlent = 12 });
            lstSource.Add(new Report() { months = "12", countlent = 37 });

            DataContext = lstSource;
        }

        private void LoadChartContents()
        {
            //List<Report> lstSource = new List<Report>();
            //lstSource.Add(new Report() { months = "1", countlent = 10 });
            //lstSource.Add(new Report() { months = "2", countlent = 15 });
            //lstSource.Add(new Report() { months = "3", countlent = 20 });
            //lstSource.Add(new Report() { months = "4", countlent = 10 });
            //lstSource.Add(new Report() { months = "5", countlent = 13 });
            //lstSource.Add(new Report() { months = "6", countlent = 18 });
            //lstSource.Add(new Report() { months = "7", countlent = 33 });
            //lstSource.Add(new Report() { months = "8", countlent = 41 });
            //lstSource.Add(new Report() { months = "9", countlent = 31 });
            //lstSource.Add(new Report() { months = "10", countlent = 21 });
            //lstSource.Add(new Report() { months = "11", countlent = 12 });
            //lstSource.Add(new Report() { months = "12", countlent = 37 });

            //DataContext = lstSource;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
