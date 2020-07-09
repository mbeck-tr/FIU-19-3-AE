using System;
using System.Threading;
using System.Threading.Tasks;

namespace WdhTaskAbbrechen
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Task.Run(() => // Typ Action
            {
                while (true)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested) break; //Prüfen, ob Task abgebrochen werden soll
                    Thread.Sleep(1000);
                    Console.WriteLine(DateTime.Now.ToLongTimeString());
                }
            }, cancellationTokenSource.Token);

            int zaehler = 0;
            while (true)
            {
                Thread.Sleep(100);
                Console.Write("X");
                zaehler++;
                if (Console.ReadKey().Key == ConsoleKey.X)
                {
                    /*Jetzt Task (Zeit) abbrechen*/
                   cancellationTokenSource.Cancel();
                }
                if (zaehler == 200)
                {
                    break;
                }
            }

            //Console.ReadLine();
        }
    }
}
