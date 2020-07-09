using System;
using System.Threading.Tasks;

namespace WdhDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            a = 10;

            DateTime datum = DateTime.Now;

            string s = "Hallo Welt";

            float f = 10.5F;

            Punkt MeineKoordinaten = new Punkt();

            //var meineMethode = DoSomething;

            MeinDelegateHandler meineDelegateVariable;

            meineDelegateVariable = DoSomething;

            meineDelegateVariable();
            meineDelegateVariable();

            meineDelegateVariable = DoSomething2;
            meineDelegateVariable();

            MeinDelegateHandler nochEineDelegateVariable = new MeinDelegateHandler(DoSomething);
            nochEineDelegateVariable();

            MeinDelegateMitRueckgabeHandler delegateMitRueckgabe;
            delegateMitRueckgabe = DoSomething3;

            Console.WriteLine("Antwort: " + delegateMitRueckgabe());

            MeinDelegateMitParameterHandler meinDelegateMitParameter = DoSomething4;
            Console.WriteLine("Anzahl Zeichen: " + meinDelegateMitParameter("Hallo Welt"));

            var del = new MeinVoidDelegateMitParameterHandler(DoSomething5);

            Action action = DoSomething;
            action();

            Action<string> action2 = DoSomething5;

            Func<int> func1 = DoSomething3;
            Func<string,double> func2 = DoSomething4;

            TestHandler testHandler = test;
            Action<string, int, double, float, DateTime, Punkt, char> actionTest = test;
            Task t = new Task(DoSomething2);

            Func<string, int, double, float, DateTime, Punkt, char, int> funcTest = test2;


            meineDelegateVariable = delegate () { Console.WriteLine("Meine Anonyme Action"); };
            Action action3 = delegate () { Console.WriteLine("Meine Anonyme Action"); };
            Func<double> func3 = delegate () { /*Ganz viel Code*/; return 3.14; };
            var pi = func3();

            Action<string> action4 = (text) => { Console.WriteLine(text); }; // Lambda-Expression
            action4("Hallo");

#nullable enable
            Action<object> action5 = (obj) => { Console.WriteLine((int)obj); };
#nullable disable

            Task task = new Task(action5, null);

            //Datenbank Tabellen varchar int = null
        }
        
        static void test(string s, int i, double d, float f, DateTime dt, Punkt p, char c)
        {
            int? I = null;
        }

        static int test2(string s, int i, double d, float f, DateTime dt, Punkt p, char c)
        {
            return 42;
        }

        // Action-Delegates
        delegate void MeinDelegateHandler();
        delegate void MeinVoidDelegateMitParameterHandler(string s1);
        delegate void TestHandler(string s, int i, double d, float f, DateTime dt, Punkt p, char c);
        // Function-Delegates
        delegate int MeinDelegateMitRueckgabeHandler();
        delegate double MeinDelegateMitParameterHandler(string s1);

        static void DoSomething()
        {
            Console.WriteLine("Code von DoSomething");
        }
        static void DoSomething2()
        {
            Console.WriteLine("Code von DoSomething2");
        }

        static int DoSomething3()
        {
            return 42;
        }

        static double DoSomething4(string s)
        {
            return s.Length;
        }

        static void DoSomething5(string s)
        {
            Console.WriteLine("Eingabe: " + s);
        }
    }
    class Punkt
    {
        int x;
        int y;
    }
}
