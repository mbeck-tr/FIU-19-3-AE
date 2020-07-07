using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
        CancellationTokenSource cts;
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

            string result = task6.Result.ToString(); // Bei Zugriff auf Result-Property wird Wait() Methode aufgerufen
            WriteOutput(result);

            #region Demonstration zur Behandlung von Ausnahmen (Ohne Debugger starten!!!)
            goto weiter; // nur zur Demonstration, nicht verwenden :-)
            Task<int> task6b = new Task<int>(MethodeMitException);
            task6b.Start();
            try
            {
                task6b.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is DivideByZeroException)
                {
                    MessageBox.Show("Division durch Null " + ex.InnerException.Message);
                }
                else
                {
                    MessageBox.Show("Irgendeine Exception " + ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception catched + " + ex.GetType());
                Debug.WriteLine("Exception catched + " + ex.Message);
            }

        weiter: // Sprungmarke, nur Demo!!!
            #endregion

            //Methode mit Übergabeparameter
            // 1. Möglichkeit
            Task<int> task7 = new Task<int>(AnzahlZeichen, "Hallo Welt");
            task7.Start();
            InvokeWriteOutput("Anzahl Zeichen: " + task7.Result.ToString());

            //2. Möglichkeit über Wrapper
            Task<int> task8 = Task.Run<int>(() =>
            {
                return AnzahlZeichenString("Hallo FIU 19/3", 12, 3.45, DateTime.Now);
            });
            WriteOutput("Anzahl Zeichen: " + task7.Result.ToString());


            // Tasks vorzeitig beenden, Task Abbruch
            cts = new CancellationTokenSource();
            var task9 = Task.Run(SchreibeX, cts.Token);

            //Continueations
            //1. Möglichkeit
            InvokeWriteOutput("Task 10 gestartet:");
            var task10 = Task.Run<int>(SinnDesLebens);
            InvokeWriteOutput("Continue With von Task10 bearbeitet");
            task10.ContinueWith((vorrigerTask) =>
           {
               int ergebnis = vorrigerTask.Result;
               MessageBox.Show("Task10 Ergebnis " + ergebnis);
           });

            //2. Möglichkeit
            var task11 = Task.Run<int>(SinnDesLebens);
            InvokeWriteOutput("Task awaiter gestartet");
            TaskAwaiter<int> awaiter = task11.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int ergebnis = awaiter.GetResult();
                MessageBox.Show("Awaiter: " + ergebnis);
            });
            InvokeWriteOutput("Awaiter onComplete gesetzt");
            
        }

        private void WriteOutput(string msg)
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
            this.Dispatcher.Invoke(new Action<string>(WriteOutput), new object[] { msg });
        }
        private int SinnDesLebens()
        {
            Thread.Sleep(5000);
            return 42;
        }
        private int MethodeMitException()
        {
            Thread.Sleep(500);
            throw new DivideByZeroException("Task Exception");
            return 42;
        }
        private int AnzahlZeichen(object zeichenfolge)
        {
            string z = (string)zeichenfolge;
            Thread.Sleep(600);
            return z.Length;
        }
        private int AnzahlZeichenString(string zeichenfolge, int param2, double param3, DateTime bla)
        {
            string z = zeichenfolge;
            Thread.Sleep(600);
            return z.Length;
        }
        private void SchreibeX()
        {
            while (true)
            {
                Thread.Sleep(1000);
                InvokeWriteOutput("X");
                if (cts.Token.IsCancellationRequested)
                {
                    InvokeWriteOutput("Abbruch!!");
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }
    }
}
