using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace WdhThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main 'O' (Foreground)";
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            //PrintThread(Thread.CurrentThread);

            //ParameterizedThreadStart DoSomethingDelegate = DoSomething;
            Thread t1 = new Thread(DoSomething);
            t1.Name = "t1 'X' (Background)";
            t1.IsBackground = true;
            t1.Priority = ThreadPriority.Lowest;

            Thread t2 = new Thread(DoSomething);
            t2.Name = "t2 '_' (Foreground)";
            t2.IsBackground = false;
            t2.Priority = ThreadPriority.Highest;

            t1.Start("X");
            t2.Start("_");
            DoSomething("O");

            Console.WriteLine("\nDoSomething aufgerufen!!!\nMainmethode beendet!!!");
        }

        static void DoSomething(object character)
        {
            //PrintThread(Thread.CurrentThread);
            for (int i = 0; i < 1000; i++)
            {
                //Thread.Sleep(10);
                Console.Write((string)character);
            }
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} beendet!!!");
        }

        private static void PrintThread(Thread threadObject)
        {
            Console.WriteLine($"{threadObject.Name}:\n" +
                            $"ID: {threadObject.ManagedThreadId}\n" +
                            $"Background: {threadObject.IsBackground}\n" +
                            $"ThreadPoolThread:{threadObject.IsThreadPoolThread}");
        }
    }
}
