using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Aufgaben2
{
    class Program
    {
        static CancellationTokenSource ctSource;
        static void Main(string[] args)
        {
            while (true)
            {

                string auswahl = menuPunktAuswaehlen();


                switch (auswahl)
                {
                    case "1":
                        Console.WriteLine("Aufgabe 1");
                        string dateipfad = @"D:\FIU-19-3-AE\FIU-19-3-AE\Aufgaben2.txt";
                        Thread threadDateiEinlesen = new Thread(DateiLesen);
                        threadDateiEinlesen.Start(dateipfad);
                        break;
                    case "2":
                        Console.WriteLine("Aufgabe 2");
                        ctSource = new CancellationTokenSource();
                        Task t = new Task(
                            //PrimzahlenAusgeben, 1000
                            ()=> PrimzahlenAusgeben(1000),
                            ctSource.Token
                            );
                        t.Start();
                        //Alternativer Aufruf
                        //Task.Run(() => PrimzahlenAusgeben(1000));
                        break;
                    case "3":
                        Console.WriteLine("Aufgabe 3");
                        Task<int[]> t2 = new Task<int[]>(PrimzahlenBerechnen,1000);
                        t2.Start();
                        Console.WriteLine("Anzahl Primzahlen: " + t2.Result.Length);
                        break;
                    case "4":
                        return;
                }
                Console.WriteLine("Bitte Taste drücken ...");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                {
                    ctSource.Cancel();
                }
            }

            Console.WriteLine("Mainmethode fertig!!!");
        }

        private static void PrimzahlenAusgeben(object bis)
        {
            int max = (int)bis;
            for (int i = 2; i <= max; i++)
            {
                Thread.Sleep(100);
                if (ctSource.IsCancellationRequested)
                {
                    Console.WriteLine("Abbruch");
                    return;
                }
                if (IstZahlEinePrimzahl(i)) Console.WriteLine(i);
            }
        }

        private static int[] PrimzahlenBerechnen(object bis)
        {
            List<int> l = new List<int>();
            int max = (int)bis;
            for (int i = 2; i <= max; i++)
            {
                if (IstZahlEinePrimzahl(i)) l.Add(i);
            }
            return l.ToArray();
        }
        private static bool IstZahlEinePrimzahl(int i)
        {
            bool istPrimzahl = true;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    istPrimzahl = false;
                    break;
                }
            }
            return istPrimzahl;
        }

        private static string menuPunktAuswaehlen()
        {
            Console.Clear();
            Console.WriteLine("1.) Datei Einlesen (Aufgabe 1)");
            Console.WriteLine("2.) Primzahlen ausgeben (Aufgabe 2)");
            Console.WriteLine("3.) Primzahlen als int-Array erhalten (Aufgabe 3)");
            Console.WriteLine("4.) Abbrechen/Beenden");
            Console.Write("Bitte wählen: ");
            return Console.ReadLine();
        }

        private static void DateiLesen(object DateiName)
        {
            string dateipfad = (string)DateiName;
            try
            {
                using (StreamReader sr = new StreamReader(dateipfad))
                {
                    string zeile;
                    while ((zeile = sr.ReadLine()) != null)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine(zeile);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Dateizugriffsfehler!!!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
