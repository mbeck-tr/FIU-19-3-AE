using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ThemaTaskAwaiterObject
{
    class Program
    {
        static void Main(string[] args)
        {
            MethAufruf();
            
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(i);
            }


            Console.WriteLine("Mainmethode fertig");
            Console.ReadLine();
        }

        static async void MethAufruf()
        {
            int a = await AsynchroneMethodeAsync();
            Console.WriteLine(a);
        }

        static Task<int> AsynchroneMethodeAsync()
        {
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return 42;
            });
            return task;
        }
    }
}
