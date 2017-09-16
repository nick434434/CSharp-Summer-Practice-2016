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
            Denom[2] = 1.86666666666676;
            Denom[3] = 0;
            Denom[4] = 1.07692307692322;
            Denom[5] = 0;
            Denom[6] = 0.195804195804245;
            Denom[7] = 0;
            Denom[8] = 0.00543900543900802;
            Numer[0] = 1.5707963267949;
            Numer[1] = -1;
            Numer[2] = 2.93215314335063;
            Numer[3] = -1.53333333333343;
            Numer[4] = 1.69162681347165;
            Numer[5] = -0.654700854700962;
            Numer[6] = 0.307568511540337;
            Numer[7] = -0.0673060273060501;
            Numer[8] = 0.00854356976501126;
            Console.Write("Input argument for Acot(x): ");
            double arg = double.Parse(Console.ReadLine());
            for (int j = 0; j < 9; j++)
            {
                double Tmp = Math.Pow(arg, j);
                P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;
            
            Console.Write("Acot(" + arg.ToString() + ") = ");
            Console.WriteLine(Res);
            Console.Write("Target value: "+ (Math.PI / 2 - Math.Atan(arg)).ToString());
            Console.WriteLine();
        }
    }
}
