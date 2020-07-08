using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Aufgabe1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> kurse = new List<string>();
        List<string> trainer = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "Main Thread";
            PrintThread(Thread.CurrentThread);
            // Erzeugen von Daten für die Listen
            for (int i = 0; i < 10; i++)
            {
                kurse.Add($"Kurs Nr. {i + 1}");
                if (i > 5) continue;
                trainer.Add($"Trainer Nr. {i + 1}");
            }
        }

        private void btnKurse_Click(object sender, RoutedEventArgs e)
        {
            // Elemente der kurse-Liste in die lbKurse aufnehmen
            Thread threadObject = new Thread(LadeKurse);
            threadObject.Name = "'KurseLaden'-Thread";
            threadObject.Priority = ThreadPriority.AboveNormal;
            threadObject.Start();
        }

        private static void PrintThread(Thread threadObject)
        {
            Debug.WriteLine($"{threadObject.Name}:\n" +
                            $"ID: {threadObject.ManagedThreadId}\n" +
                            $"Background: {threadObject.IsBackground}\n" +
                            $"ThreadPoolThread:{threadObject.IsThreadPoolThread}");
        }

        private void btnTrainer_Click(object sender, RoutedEventArgs e)
        {
            // Elemente der trainer-Liste in die lbTrainer aufnehmen
            Task taskObject = new Task(LadeTrainer);
            taskObject.Start();

            var t1 = Task.Factory.StartNew(LadeTrainer);
            var t2 = Task.Run(LadeTrainer);
        }
        private void LadeKurse()
        {
            Debug.WriteLine("Lade Kurse\n-----------");
            PrintThread(Thread.CurrentThread);
            foreach (string item in kurse)
            {
                Thread.Sleep(500); //Simulation einer langsamen Datenverbindung
                this.Dispatcher.Invoke(() => lbKurse.Items.Add(item));
            }
        }
        private void LadeTrainer()
        {
            foreach (string item in trainer)
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke(()=>lbTrainer.Items.Add(item));
            }
        }


    }
}
