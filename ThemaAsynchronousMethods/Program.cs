using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ThemaAsynchronousMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                DisplaySum(i);
            }
            Console.WriteLine("Nach Aufruf von DiplayMethode");
            Console.ReadLine();
        }

        static async void DisplaySum(int to)
        {

                int ergebnis = await GetSumFromToAsync(to * 100, (to + 1) * 100);
                Console.WriteLine("Ergebnis: " +  ergebnis);

                //Task<int> t = GetSumFromToAsync(i * 100, (i + 1) * 100);
                //TaskAwaiter<int> awaiter = t.GetAwaiter();
                //awaiter.OnCompleted(() =>
                //{
                //    Console.WriteLine($"Ergebnis: " + awaiter.GetResult());
                //});
        }

        static Task<int> GetSumFromToAsync(int start, int end)
        {
            return Task.Run(() =>
            {
                int sum = 0;
                for (int i = start; i <= end; i++)
                {
                    Thread.Sleep(1);
                    sum += i;
                }
                return sum;
            });

        }



    }
}
