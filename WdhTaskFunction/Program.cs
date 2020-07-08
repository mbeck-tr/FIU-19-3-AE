using System;
using System.Threading;
using System.Threading.Tasks;

namespace WdhTaskFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Task<double>(Calculation, 500); //Task mit Methode mit Rückgabewert
            t1.Start();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(40);
                Console.WriteLine(i);
                if (t1.IsCompleted) Console.WriteLine(t1.Result);
            }
            //t1.Wait();                    //Warten bis Ergebnis da ist
            Console.WriteLine(t1.Result);   //Ergebnis ist in Result festgehalten

            Console.WriteLine("fertig!!!");
            Console.ReadKey();
        }

        static double Calculation(object time)
        {
            Thread.Sleep((int)time);
            Console.WriteLine(Math.PI * (double)(int)time * 2);
            return Math.PI * (double)(int)time * 2;
        }
    }
}
