using System;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;

namespace WdhTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(DoSomething,"X");
            t1.Start();
            Task t2 = Task.Factory.StartNew(DoSomething, "_");

            t1.Wait();
            Console.WriteLine("fertig!");
            //Console.ReadKey();
        }

        static void DoSomething(object character)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.Write((string)character);
            }
        }

        
    }
}
