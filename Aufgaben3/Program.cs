using System;

namespace Aufgaben3
{
    class Program
    {
        //delegate double CalculateHandler(double a, double b);
        static void Main(string[] args)
        {
            //CalculateHandler calculate;

            Func<double,double,double> calculate;

            Console.Write("Operation (+,-,x,/)? ");
            string eingabe = Console.ReadLine();
            switch (eingabe)
            {
                case "+":
                    calculate = Addition;
                    break;
                case "-":
                    calculate = Subtraction;
                    break;
                case "x":
                    calculate = Multiplication;
                    break;
                case "/":
                    calculate = Division;
                    break;
                default:
                    calculate = Addition;
                    break;
            }

            Console.Write("Zahl1: ");
            string zahl1 = Console.ReadLine();
            Console.Write("Zahl2: ");
            string zahl2 = Console.ReadLine();

            Console.Write("Zahl3: ");
            string zahl3 = Console.ReadLine();

            double z1 = Convert.ToDouble(zahl1);
            double z2 = Convert.ToDouble(zahl2);
            double z3;
            double ergebnis;

            if (double.TryParse(zahl3,out z3))
            {
                ergebnis = calculate(calculate(z1, z2), z3);

            }
            else
            {
                ergebnis = calculate(z1, z2);
            }
            Console.WriteLine("Ergebnis: " + ergebnis);
        }
        static double Addition(double zahl1, double zahl2)
        {
            return zahl1 + zahl2;
        }

        static double Subtraction(double z1, double z2)
        {
            return z1 - z2;
        }
        static double Multiplication(double z1, double z2)
        {
            return z1 * z2;
        }
        static double Division(double z1, double z2)
        {
            return z1 / z2;
        }

        static double Sum(double z1, double z2, double z3)
        {
            return z1 + z2 + z3;
        }
    }
}
