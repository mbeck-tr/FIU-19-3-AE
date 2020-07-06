using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ThemaThreads
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "Hauptthread";
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Delegate auf die Methode, welche in eigenem Thread abgearbeitet werden soll
            // ThreadStart threadStart = new ThreadStart(Berechne);
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(Berechne);
            
            // Instanziierung des Threadobjekts mit Übergabe des Delegaten
            Thread berechneThread = new Thread(parameterizedThreadStart);
            berechneThread.Name = "Nebenthread 1";
            Thread berechneThread2 = new Thread(new ParameterizedThreadStart(Berechne));
            berechneThread2.Name = "Thread 2";
            berechneThread2.IsBackground = true; // Hintergrundthreads werden beendet sobald letzter Vordergrundthread beendet ist

            berechneThread.Start(10);

            Berechne(5);

            berechneThread.Join(); // wartet bis angegebener Thread beendet ist!
            berechneThread2.Start(15);

            /*
            
            Mögliche Methodensignaturen für Threads:
            1) void Methodenname();
            2) void Methodenname(object Parameter);

            Hauptthread (Windows Programm) ist immer Vordergrundthread

            Start

            |
            |
            |
            | \  Berechne Methode im eigenen Thread (Vordergrund oder Hintergrundthread)
            |  \
            |   \
            |           Scheduler des OS wechselt zw. den Threads (Priorität)
                |
            |
                |
            |   
                |
            |   
                |
            |   
                |
            |   
                |
            |   Ende
            |
            |
                            
            Ende


             */

            //Berechne();

            sw.Stop();
            Debug.WriteLine("Gesamtzeit: " + sw.ElapsedMilliseconds / 1000.0);
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo " + Thread.CurrentThread.Name);
        }

        private void Berechne(object anzahlWiederholung)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < (int)anzahlWiederholung; i++)
            {
                Thread.Sleep(500);
                Debug.WriteLine("Programm arbeitet {0} im {1}", i+1, Thread.CurrentThread.Name);
            }

            sw.Stop();
            Debug.WriteLine("Zeit: " + sw.ElapsedMilliseconds / 1000.0);
        }

        private void btnLocalVariable_Click(object sender, RoutedEventArgs e)
        {
            Thread tuewas1 = new Thread(new ThreadStart(TueWas));
            Thread tuewas2 = new Thread(TueWas);
            tuewas1.Start();
            tuewas2.Start();
        }


        bool fertig = false; // shared Variable

        private void TueWas()
        {
            int a = 10; // lokale Variable
            if (a == 10) { a++; Debug.WriteLine("a: " + a + "\t" + Thread.CurrentThread.ManagedThreadId); }
        }

        private void TueWasShared()
        {
            int a = 10; // lokale Variable
            if (a == 10) { a++; Debug.WriteLine("a: " + a + "\t" + Thread.CurrentThread.ManagedThreadId); }
            if (!fertig) { fertig = true; Debug.WriteLine("Fertig! {0}", Thread.CurrentThread.ManagedThreadId);  }
        }

        private void btnSharedVariable_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(TueWasShared);
            Thread t2 = new Thread(TueWasShared);
            t1.Start();
            t2.Start();
        }

        private bool done = false;
        static readonly object locker = new object();
        private void TueWasThreadSafty()
        {
            //Monitor.Enter(locker);
            lock (locker)
            {
                if (!done)
                {
                    Debug.WriteLine("Done! {0}", Thread.CurrentThread.ManagedThreadId);
                    done = true;
                }
            }
            //Monitor.Exit(locker);
        }

        private void btnThreadSafty_Click(object sender, RoutedEventArgs e)
        {
            new Thread(TueWasThreadSafty).Start();
            new Thread(TueWasThreadSafty).Start();
        }

        private void MethodeUeberThreadpool(object obj)
        {
            int n1, n2, n3;
            Debug.WriteLine($"-> Thread {(int)obj} gestartet");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
            ThreadPool.GetMaxThreads(out n3, out n2);
            ThreadPool.GetAvailableThreads(out n1, out n2);
            Debug.WriteLine($"<- Thread {(int)obj} beendet! (frei {n1} von {n3}");

        }

        private void btnThreadPool_Click(object sender, RoutedEventArgs e)
        {
            int n2, n3;
            ThreadPool.GetMaxThreads(out n2, out n3);
            Debug.WriteLine("Max Threads im ThreadPool: " + n2);
            //ThreadPoolthreads sind immer Hintergrundthreads
            //ThreadPool.QueueUserWorkItem(MethodeUeberThreadpool, 1);
            //ThreadPool.QueueUserWorkItem(MethodeUeberThreadpool, 2);
            //ThreadPool.QueueUserWorkItem(MethodeUeberThreadpool, 3);
            //ThreadPool.QueueUserWorkItem(MethodeUeberThreadpool, 4);
            //ThreadPool.QueueUserWorkItem(MethodeUeberThreadpool, 5);
            for (int i = 0; i < (n2 + 10); i++)
            {
                ThreadPool.QueueUserWorkItem(MethodeUeberThreadpool, i);
                Debug.WriteLine($"Thread_{i} in Warteschlange aufgenommen");
            }
        }

        private void btnUpdateControl_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(LoadCustomers); t.Start();
        }

        private void LoadCustomers()
        {
            List<string> liste = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                liste.Add($"Customer Nr. {i + 1}");
            }
            this.Dispatcher.Invoke(new UpdateUIDelegateList(UpdateListBox), new object[] { liste });
            
        }

        delegate void UpdateUIDelegateList(List<string> list);
        private void UpdateListBox(List<string> liste)
        {
            lbCustomers.ItemsSource = liste;
        }
    }
}
