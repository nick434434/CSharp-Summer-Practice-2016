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
            double[] Denom = new double[9];
            double[] Numer = new double[9];
            Denom[0] = 1;
            Denom[1] = 0;
            Denom[2] = -1.68574455535984;
            Denom[3] = 0;
            Denom[4] = 0.852222713701653;
            Denom[5] = 0;
            Denom[6] = -0.12765005836569;
            Denom[7] = 0;
            Denom[8] = 0.00223281511982538;
            Numer[0] = 1.5707963267949;
            Numer[1] = -1;
            Numer[2] = -2.64796135547374;
            Numer[3] = 1.51907788869318;
            Numer[4] = 1.33866830829374;
            Numer[5] = -0.646265287808346;
            Numer[6] = -0.20051224279598;
            Numer[7] = 0.0674009239245458;
            Numer[8] = 0.00350729778863382;
            Console.Write("Input argument for Acos(x): ");
            double arg = double.Parse(Console.ReadLine());
            for (int j = 0; j < 9; j++)
            {
                double Tmp = Math.Pow(arg, j);
                P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;
            
            Console.Write("Acos(" + arg.ToString() + ") = ");
            Console.WriteLine(Res);
            Console.Write("Target value: " + Math.Acos(arg).ToString());
            Console.WriteLine();
        }
    }
}
