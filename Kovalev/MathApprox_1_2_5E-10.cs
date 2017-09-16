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
            double P1 = 1;
            double[] Denom = new double[8];
            double[] Numer = new double[8];
            Denom[0] = 1;
            Denom[1] = 3.50000000365218;
            Denom[2] = 4.84615385731428;
            Denom[3] = 3.36538462835108;
            Denom[4] = 1.22377623088198;
            Denom[5] = 0.220279722117746;
            Denom[6] = 0.0163170165091177;
            Denom[7] = 0.000291375296230911;
            Numer[0] = 0;
            Numer[1] = 1;
            Numer[2] = 3.00000000365218;
            Numer[3] = 3.42948718882153;
            Numer[4] = 1.85897436757799;
            Numer[5] = 0.481468534898159;
            Numer[6] = 0.0519813525289791;
            Numer[7] = 0.00151098903443908;
            Console.Write("Input argument for ln(1 + x): ");
            double arg = double.Parse(Console.ReadLine());
            for (int j = 1; j < 8; j++)
            {
                double Tmp = Math.Pow(arg, j);
                P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;
            
            Console.Write("Ln(1 + " + arg.ToString() + ") = ");
            Console.WriteLine(Res);
            Console.Write("Target value: " + Math.Log(arg + 1).ToString());
            Console.WriteLine();
        }
    }
}
