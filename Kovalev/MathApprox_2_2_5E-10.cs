using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            double P0 = 0;
            double P1 = 0;
            double[] Denom = new double[14];
            double[] Numer = new double[14];
            Denom[0] = 1;
            Denom[1] = 0;
            Denom[2] = 3.12000000003049;
            Denom[3] = 0;
            Denom[4] = 3.73043478269035;
            Denom[5] = 0;
            Denom[6] = 2.13167701871318;
            Denom[7] = 0;
            Denom[8] = 0.589016018340745;
            Denom[9] = 0;
            Denom[10] = 0.0692960021597361;
            Denom[11] = 0;
            Denom[12] = 0.00230986673876039;
            Denom[13] = 0;
            Numer[0] = 0;
            Numer[1] = 1;
            Numer[2] = 0;
            Numer[3] = 2.78666666669716;
            Numer[4] = 0;
            Numer[5] = 2.89043478268019;
            Numer[6] = 0;
            Numer[7] = 1.36934161496535;
            Numer[8] = 0;
            Numer[9] = 0.289940794033559;
            Numer[10] = 0;
            Numer[11] = 0.0221310542130369;
            Numer[12] = 0;
            Numer[13] = 0.000268581548936428;
            Console.Write("Input argument for Atan(x): ");
            double arg = double.Parse(Console.ReadLine());
            for (int j = 0; j < 14; j++)
            {
                double Tmp = Math.Pow(arg, j);
                P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;
            
            Console.Write("Arctg(" + arg.ToString() + ") = ");
            Console.WriteLine(Res);
            Console.Write("Target value: " + Math.Atan(arg).ToString());
            Console.WriteLine();
        }
    }
}
