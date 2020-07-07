using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThemaTasks
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

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //KomplexeBerechnung(); //Aufruf im Hauptthread

            // Thread
            //Thread t = new Thread(KomplexeBerechnung);
            //t.IsBackground = true;
            //t.Start();

            // Task erzeugen (immer Thread aus dem ThreadPool)
            Task task1 = new Task(KomplexeBerechnung);
            task1.Start();

            Task task2 = new Task(delegate () { string nachricht = "Nachricht von task2!"; InvokeWriteOutput(nachricht); });
            task2.Start();

            Task task3 = new Task(() => { Thread.Sleep(3000); InvokeWriteOutput("lambda expression von task3"); });
            task3.Start();

            var task4 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(200);
                    InvokeWriteOutput("Factory " + i);
                }
            });

            //ab .NET 4.5
            Task task5 = Task.Run(KomplexeBerechnung);

            Task<int> task6 = new Task<int>(SinnDesLebens);
            task6.Start();
            //task6.Wait();

            string result = task6.Result.ToString();
            WriteOuput(result);
        }

        private void WriteOuput(string msg)
        {
            tblOutput.Text += msg + Environment.NewLine;
        }

        private void KomplexeBerechnung()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                //this.Dispatcher.Invoke(new Action<string>(WriteOuput), new object[] { $"Berechnung für {i} durchgeführt!!" });
                InvokeWriteOutput($"Berechnung für {i} durchgeführt!!");
                Debug.WriteLine($"Berechnung für {i} durchgeführt!!");
                //WriteOuput($"Berechnung für {i} durchgeführt!!");
            }
        }

        private void InvokeWriteOutput(string msg)
        {
            this.Dispatcher.Invoke(new Action<string>(WriteOuput), new object[] { msg });
        }

        private int SinnDesLebens()
        {
            Thread.Sleep(5000);
            return 42;
        }
    }
}
