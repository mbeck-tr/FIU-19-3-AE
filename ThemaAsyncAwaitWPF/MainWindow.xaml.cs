using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThemaAsyncAwaitWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string pfad = @"d:\FIU-19-3-AE\FIU-19-3-AE\Aufgaben2.txt";
            textblock.Text = await LadenAsync(pfad);
        }

        private Task<string> LadenAsync(string pfad) 
        {
            return Task<string>.Run(
                () => 
                {
                    StreamReader sr = new StreamReader(pfad);
                    return sr.ReadToEnd();
                });
        }

        private async void btnLoad2_Click(object sender, RoutedEventArgs e)
        {
            string pfad = @"d:\FIU-19-3-AE\FIU-19-3-AE\Aufgaben3.txt";
            StreamReader sr = new StreamReader(pfad);
            Task<string> t = sr.ReadToEndAsync();
            Debug.WriteLine("Laden gestartet");
            string text = await t;
            textblock.Text = text;
        }

        private async void btnLoad3_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(new Uri("http://www.lunduke.com"));
            string content = await response.Content.ReadAsStringAsync();
            textblock.Text = content;
        }
    }
}
