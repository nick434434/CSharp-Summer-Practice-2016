#define DEBUG

using System;


namespace OpaqueFunctions
{
    public static class CMathApprox_1
    {

        public static string MathApprox_1_2(string PathName, double error)
        {

            int L = 0;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > MathApprox_1_2_CheckError(L, M))
                    break;
                if (L == M)
                    M++;
                else
                    L++;
            }

            //creating suitable approximation;
            //Ln_Numer is the numerator, Ln_Denom is the denominator, C is the Taylor approximation
            double[] C = new double[L + M + 1];
            C[0] = 0;
            for (int i = 1; i < L + M + 1; i++)
                C[i] = 1.0 / i * Math.Pow(-1, i + 1);

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);
            

            //creating program with found approximation
            string FileName = PathName + "MathApprox_1_2" + "_" + error.ToString() + ".cs";
            System.IO.StreamWriter FileWriter = CMakeProgram.MakeBeginning(PathName, "MathApprox_1_2", error);


            //!!! 
            //Необходимо заменить Ln_Numer и Ln_Denom на реально полученные коэффициенты !!!
            FileWriter.WriteLine("            double P0 = 0;");
            FileWriter.WriteLine("            double P1 = 1;");
            FileWriter.WriteLine("            double[] Denom = new double[" + (M + 1).ToString() + "];");
            FileWriter.WriteLine("            double[] Numer = new double[" + (L + 1).ToString() + "];");
            for (int i = 0; i < M + 1; i++)
                FileWriter.WriteLine("            Denom[" + i.ToString() + "] = " + Denom[i].ToString().Replace(",", ".") + ";");
            for (int i = 0; i < L + 1; i++)
                FileWriter.WriteLine("            Numer[" + i.ToString() + "] = " + Numer[i].ToString().Replace(",", ".") + ";");
            FileWriter.WriteLine("            Console.Write(\"Input argument for ln(1 + x): \");");
            FileWriter.WriteLine("            double arg = double.Parse(Console.ReadLine());");
            FileWriter.WriteLine("            for (int j = 1; j < " + (M + 1).ToString() + "; j++)");
            FileWriter.WriteLine("            {");
            FileWriter.WriteLine("                double Tmp = Math.Pow(arg, j);");
            FileWriter.WriteLine("                P0 += Numer[j] * Tmp;");
            FileWriter.WriteLine("                P1 += Denom[j] * Tmp;");
            FileWriter.WriteLine("            }");
            FileWriter.WriteLine("            double Res = P0 / P1;");
            FileWriter.WriteLine("            ");
            FileWriter.WriteLine("            Console.Write(\"Ln(1 + \" + arg.ToString() + \") = \");");
            FileWriter.WriteLine("            Console.WriteLine(Res);");
            FileWriter.WriteLine("            Console.Write(\"Target value: \" + Math.Log(arg + 1).ToString());");
            FileWriter.WriteLine("            Console.WriteLine();");

            FileWriter.WriteLine("        }");
            FileWriter.WriteLine("    }");
            FileWriter.WriteLine("}");
            FileWriter.Close();
            return FileName;
        }

        public static double MathApprox_1_2_CheckError(int L, int M)
        {
            if ((L == 1) && (M == 2))
                return 0.005;
            double[] C = new double[L + M + 1];
            C[0] = 0;
            for (int i = 1; i < L + M + 1; i++)
                C[i] = 1.0 / i * Math.Pow(-1, i + 1);

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];
            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double error = 0;

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double arg = 0.001 * rnd.Next(1000);
                double P0 = 0;
                double P1 = 1;
                for (int j = 1; j < M + 1; j++)
                {
                    double Tmp = Math.Pow(arg, j);
                    if (j <= L)
                        P0 += Numer[j] * Tmp;
                    P1 += Denom[j] * Tmp;
                }
                double Res = P0 / P1;

                double Temp = Math.Abs(Math.Log(arg + 1) - Res);
                if (error < Temp)
                    error = Temp;
             }

            return error;
        }

        public static string MathApprox_1_2_in()
        {
            return "(-0.5, 0.5)";
        }

    }
  
    
    /// <summary>
    /// Реализует аппроксимацию Паде функции ln(1 + x),
    /// где аргумент X задается параметром <paramref name="arg"/>, 
    /// а допустимая погрешность задается параметром <paramref name="error"/>
    /// Результатом функции является вещественное число Res - приближенное значение функции ln(1 + x)
    /// </summary>
    /// <param name="arg">Угол в радианах</param>
    /// <param name="error">Допустимая погрешность (безразмерная)<param/>
    /// <returns>ln(1 + x)</returns>
    [OpaqueFunction()]
    [FunctionName("MathApprox_1_Compute", "Ln(1 + x)")]
    public static class CMathApprox_1_Compute
    {

        public static double MathApprox_1_Compute_2(double arg, double error)
        {
            int L = 0;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > CMathApprox_1.MathApprox_1_2_CheckError(L, M))
                    break;
                if (L == M)
                    M++;
                else
                    L++;
            }

            //creating suitable approximation;
            //Ln_Numer is the numerator, Ln_Denom is the denominator, C is the Taylor approximation
            double[] C = new double[L + M + 1];
            C[0] = 0;
            for (int i = 1; i < L + M + 1; i++)
                C[i] = 1.0 / i * Math.Pow(-1, i + 1);

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double P0 = 0;
            double P1 = 1;
            for (int j = 1; j < M + 1; j++)
            {
                double Tmp = Math.Pow(arg, j);
                if (j <= L)
                    P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;

            return Res;
        }

        public static string MathApprox_1_Compute_2_in()
        {
            return "(-0.5, 0.5) (w, w)";
        }
    }



    public static class CMathApprox_2
    {
        public static string MathApprox_2_2(string PathName, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > MathApprox_2_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            //creating suitable approximation;
            //Ln_Numer is the numerator, Ln_Denom is the denominator, C is the Taylor approximation
            double[] C = new double[L + M + 1];
            int p = 0;
            for (int i = 0; i < L + M + 1; i++)
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                {
                    C[i] = 1.0 / i * Math.Pow(-1, p);
                    p++;
                }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);


            //creating program with found approximation
            string FileName = PathName + "MathApprox_2_2" + "_" + error.ToString() + ".cs";
            System.IO.StreamWriter FileWriter = CMakeProgram.MakeBeginning(PathName, "MathApprox_2_2", error);

            
            //!!! 
            //Необходимо заменить Ln_Numer и Ln_Denom на реально полученные коэффициенты !!!
            FileWriter.WriteLine("            double P0 = 0;");
            FileWriter.WriteLine("            double P1 = 0;");
            FileWriter.WriteLine("            double[] Denom = new double[" + (M + 1).ToString() + "];");
            FileWriter.WriteLine("            double[] Numer = new double[" + (L + 1).ToString() + "];");
            for (int i = 0; i < M + 1; i++)
                FileWriter.WriteLine("            Denom[" + i.ToString() + "] = " + Denom[i].ToString().Replace(",", ".") + ";");
            for (int i = 0; i < L + 1; i++)
                FileWriter.WriteLine("            Numer[" + i.ToString() + "] = " + Numer[i].ToString().Replace(",", ".") + ";");
            FileWriter.WriteLine("            Console.Write(\"Input argument for Atan(x): \");");
            FileWriter.WriteLine("            double arg = double.Parse(Console.ReadLine());");
            FileWriter.WriteLine("            for (int j = 0; j < " + (M + 1).ToString() + "; j++)");
            FileWriter.WriteLine("            {");
            FileWriter.WriteLine("                double Tmp = Math.Pow(arg, j);");
            FileWriter.WriteLine("                P0 += Numer[j] * Tmp;");
            FileWriter.WriteLine("                P1 += Denom[j] * Tmp;");
            FileWriter.WriteLine("            }");
            FileWriter.WriteLine("            double Res = P0 / P1;");
            FileWriter.WriteLine("            ");
            FileWriter.WriteLine("            Console.Write(\"Arctg(\" + arg.ToString() + \") = \");");
            FileWriter.WriteLine("            Console.WriteLine(Res);");
            FileWriter.WriteLine("            Console.Write(\"Target value: \" + Math.Atan(arg).ToString());");
            FileWriter.WriteLine("            Console.WriteLine();");

            FileWriter.WriteLine("        }");
            FileWriter.WriteLine("    }");
            FileWriter.WriteLine("}");
            FileWriter.Close();
            return FileName;
        }

        public static double MathApprox_2_2_CheckError(int L, int M)
        {
            double[] C = new double[L + M + 1];
            int k = 0;
            for (int i = 0; i < L + M + 1; i++)
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                {
                    C[i] = 1.0 / i * Math.Pow(-1, k);
                    k++;
                }
            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];
            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double error = 0;

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double arg = 0.001 * rnd.Next(1000);
                double P0 = 0;
                double P1 = 1;
                for (int j = 1; j < M + 1; j++)
                {
                    double Tmp = Math.Pow(arg, j);
                    if (j <= L)
                        P0 += Numer[j] * Tmp;
                    P1 += Denom[j] * Tmp;
                }
                double Res = P0 / P1;

                double Temp = Math.Abs(Math.Atan(arg) - Res);
                if (error < Temp)
                    error = Temp;
            }

            return error;
        }

        public static string MathApprox_2_2_in()
        {
            return "(-1, 1)";
        }
    }

    /// <summary>
    /// Реализует аппроксимацию Паде функции Atan(x),
    /// где аргумент X задается параметром <paramref name="arg"/>, 
    /// а допустимая погрешность задается параметром <paramref name="error"/>
    /// Результатом функции является вещественное число Res - приближенное значение функции Atan(x)
    /// </summary>
    /// <param name="arg">Аргумент функции</param>
    /// <param name="error">Допустимая погрешность (безразмерная)<param/>
    /// <returns>Atan(x)</returns>
    [OpaqueFunction()]
    [FunctionName("MathApprox_2_Compute", "Atan(x)")]
    public static class CMathApprox_2_Compute
    {

        public static double MathApprox_2_Compute_2(double arg, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > CMathApprox_2.MathApprox_2_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            double[] C = new double[L + M + 1];
            int p = 0;
            for (int i = 0; i < L + M + 1; i++)
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                {
                    C[i] = 1.0 / i * Math.Pow(-1, p);
                    p++;
                }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double P0 = 0;
            double P1 = 1;
            for (int j = 1; j < M + 1; j++)
            {
                double Tmp = Math.Pow(arg, j);
                if (j <= L)
                    P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;

            return Res;
        }

        public static string MathApprox_2_Compute_2_in()
        {
            return "(-1, 1) (w, w)";
        }
    }

    public static class CMathApprox_3
    {
        public static string MathApprox_3_2(string PathName, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > MathApprox_3_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            //creating suitable approximation;
            //Ln_Numer is the numerator, Ln_Denom is the denominator, C is the Taylor approximation
            double[] C = new double[L + M + 1];
            C[0] = 0; C[1] = 1;
            for (int i = 2; i < L + M + 1; i++)
            {
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                    C[i] = C[i - 2] * (i - 2) * (i - 2) / i / (i - 1);
            }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);


            //creating program with found approximation
            string FileName = PathName + "MathApprox_3_2" + "_" + error.ToString() + ".cs";
            System.IO.StreamWriter FileWriter = CMakeProgram.MakeBeginning(PathName, "MathApprox_3_2", error);


            //!!! 
            //Необходимо заменить Ln_Numer и Ln_Denom на реально полученные коэффициенты !!!
            FileWriter.WriteLine("            double P0 = 0;");
            FileWriter.WriteLine("            double P1 = 0;");
            FileWriter.WriteLine("            double[] Denom = new double[" + (M + 1).ToString() + "];");
            FileWriter.WriteLine("            double[] Numer = new double[" + (L + 1).ToString() + "];");
            for (int i = 0; i < M + 1; i++)
                FileWriter.WriteLine("            Denom[" + i.ToString() + "] = " + Denom[i].ToString().Replace(",", ".") + ";");
            for (int i = 0; i < L + 1; i++)
                FileWriter.WriteLine("            Numer[" + i.ToString() + "] = " + Numer[i].ToString().Replace(",", ".") + ";");
            FileWriter.WriteLine("            Console.Write(\"Input argument for Asin(x): \");");
            FileWriter.WriteLine("            double arg = double.Parse(Console.ReadLine());");
            FileWriter.WriteLine("            for (int j = 0; j < " + (M + 1).ToString() + "; j++)");
            FileWriter.WriteLine("            {");
            FileWriter.WriteLine("                double Tmp = Math.Pow(arg, j);");
            FileWriter.WriteLine("                P0 += Numer[j] * Tmp;");
            FileWriter.WriteLine("                P1 += Denom[j] * Tmp;");
            FileWriter.WriteLine("            }");
            FileWriter.WriteLine("            double Res = P0 / P1;");
            FileWriter.WriteLine("            ");
            FileWriter.WriteLine("            Console.Write(\"Asin(\" + arg.ToString() + \") = \");");
            FileWriter.WriteLine("            Console.WriteLine(Res);");
            FileWriter.WriteLine("            Console.Write(\"Target value: \" + Math.Asin(arg).ToString());");
            FileWriter.WriteLine("            Console.WriteLine();");

            FileWriter.WriteLine("        }");
            FileWriter.WriteLine("    }");
            FileWriter.WriteLine("}");
            FileWriter.Close();
            return FileName;
        }

        public static double MathApprox_3_2_CheckError(int L, int M)
        {
            double[] C = new double[L + M + 1];
            C[0] = 0; C[1] = 1;
            for (int i = 2; i < L + M + 1; i++)
            {
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                    C[i] = C[i - 2] * (i - 2) * (i - 2) / i / (i - 1);
            }
            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];
            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double error = 0;

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double arg = 0.001 * rnd.Next(500);
                double P0 = 0;
                double P1 = 1;
                for (int j = 1; j < M + 1; j++)
                {
                    double Tmp = Math.Pow(arg, j);
                    if (j <= L)
                        P0 += Numer[j] * Tmp;
                    P1 += Denom[j] * Tmp;
                }
                double Res = P0 / P1;

                double Temp = Math.Abs(Math.Asin(arg) - Res);
                if (error < Temp)
                    error = Temp;
            }

            return error;
        }

        public static string MathApprox_3_2_in()
        {
            return "(-0.5, 0.5) (-w, w)";
        }
    }

    /// <summary>
    /// Реализует аппроксимацию Паде функции Asin(x),
    /// где аргумент X задается параметром <paramref name="arg"/>, 
    /// а допустимая погрешность задается параметром <paramref name="error"/>
    /// Результатом функции является вещественное число Res - приближенное значение функции Asin(x)
    /// </summary>
    /// <param name="arg">Аргумент функции</param>
    /// <param name="error">Допустимая погрешность (безразмерная)<param/>
    /// <returns>Asin(x)</returns>
    [OpaqueFunction()]
    [FunctionName("MathApprox_3_Compute", "Asin(x)")]
    public static class CMathApprox_3_Compute
    {
        public static double MathApprox_3_Compute_2(double arg, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > CMathApprox_3.MathApprox_3_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            double[] C = new double[L + M + 1];
            C[0] = 0; C[1] = 1;
            for (int i = 2; i < L + M + 1; i++)
            {
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                    C[i] = C[i - 2] * (i - 2) * (i - 2) / i / (i - 1);
            }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double P0 = 0;
            double P1 = 1;
            for (int j = 1; j < M + 1; j++)
            {
                double Tmp = Math.Pow(arg, j);
                if (j <= L)
                    P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;

            return Res;
        }

        public static string MathApprox_3_Compute_2_in()
        {
            return "(-0.5, 0.5) (-w, w)";
        }
    }


    public static class CMathApprox_4
    {
        public static string MathApprox_4_2(string PathName, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > MathApprox_4_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            //creating suitable approximation;
            //Ln_Numer is the numerator, Ln_Denom is the denominator, C is the Taylor approximation
            double[] C = new double[L + M + 1];
            int p = 0;
            C[0] = Math.PI / 2;
            for (int i = 1; i < L + M + 1; i++)
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                {
                    C[i] = 1.0 / i * Math.Pow(-1, p + 1);
                    p++;
                }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);


            //creating program with found approximation
            string FileName = PathName + "MathApprox_4_2" + "_" + error.ToString() + ".cs";
            System.IO.StreamWriter FileWriter = CMakeProgram.MakeBeginning(PathName, "MathApprox_4_2", error);


            //!!! 
            //Необходимо заменить Ln_Numer и Ln_Denom на реально полученные коэффициенты !!!
            FileWriter.WriteLine("            double P0 = 0;");
            FileWriter.WriteLine("            double P1 = 0;");
            FileWriter.WriteLine("            double[] Denom = new double[" + (M + 1).ToString() + "];");
            FileWriter.WriteLine("            double[] Numer = new double[" + (L + 1).ToString() + "];");
            for (int i = 0; i < M + 1; i++)
                FileWriter.WriteLine("            Denom[" + i.ToString() + "] = " + Denom[i].ToString().Replace(",", ".") + ";");
            for (int i = 0; i < L + 1; i++)
                FileWriter.WriteLine("            Numer[" + i.ToString() + "] = " + Numer[i].ToString().Replace(",", ".") + ";");
            FileWriter.WriteLine("            Console.Write(\"Input argument for Acot(x): \");");
            FileWriter.WriteLine("            double arg = double.Parse(Console.ReadLine());");
            FileWriter.WriteLine("            for (int j = 0; j < " + (M + 1).ToString() + "; j++)");
            FileWriter.WriteLine("            {");
            FileWriter.WriteLine("                double Tmp = Math.Pow(arg, j);");
            FileWriter.WriteLine("                P0 += Numer[j] * Tmp;");
            FileWriter.WriteLine("                P1 += Denom[j] * Tmp;");
            FileWriter.WriteLine("            }");
            FileWriter.WriteLine("            double Res = P0 / P1;");
            FileWriter.WriteLine("            ");
            FileWriter.WriteLine("            Console.Write(\"Acot(\" + arg.ToString() + \") = \");");
            FileWriter.WriteLine("            Console.WriteLine(Res);");
            FileWriter.WriteLine("            Console.Write(\"Target value: \"+ (Math.PI / 2 - Math.Atan(arg)).ToString());");
            FileWriter.WriteLine("            Console.WriteLine();");

            FileWriter.WriteLine("        }");
            FileWriter.WriteLine("    }");
            FileWriter.WriteLine("}");
            FileWriter.Close();
            return FileName;
        }

        public static double MathApprox_4_2_CheckError(int L, int M)
        {
            double[] C = new double[L + M + 1];
            int p = 0;
            C[0] = Math.PI / 2;
            for (int i = 1; i < L + M + 1; i++)
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                {
                    C[i] = 1.0 / i * Math.Pow(-1, p + 1);
                    p++;
                }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];
            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double error = 0;

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double arg = 0.001 * rnd.Next(500);
                double P0 = 0;
                double P1 = 0;
                for (int j = 0; j < M + 1; j++)
                {
                    double Tmp = Math.Pow(arg, j);
                    if (j <= L)
                        P0 += Numer[j] * Tmp;
                    P1 += Denom[j] * Tmp;
                }
                double Res = P0 / P1;

                double Temp = Math.Abs((Math.PI / 2 - Math.Atan(arg)) - Res);
                if (error < Temp)
                    error = Temp;
            }

            return error;
        }

        public static string MathApprox_4_2_in()
        {
            return "(-0.5, 0.5) (-w, w)";
        }
    }

    /// <summary>
    /// Реализует аппроксимацию Паде функции Asin(x),
    /// где аргумент X задается параметром <paramref name="arg"/>, 
    /// а допустимая погрешность задается параметром <paramref name="error"/>
    /// Результатом функции является вещественное число Res - приближенное значение функции Asin(x)
    /// </summary>
    /// <param name="arg">Аргумент функции</param>
    /// <param name="error">Допустимая погрешность (безразмерная)<param/>
    /// <returns>Asin(x)</returns>
    [OpaqueFunction()]
    [FunctionName("MathApprox_4_Compute", "Acotn(x)")]
    public static class CMathApprox_4_Compute
    {
        public static double MathApprox_4_Compute_2(double arg, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > CMathApprox_4.MathApprox_4_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            double[] C = new double[L + M + 1];
            int p = 0;
            C[0] = Math.PI / 2;
            for (int i = 1; i < L + M + 1; i++)
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                {
                    C[i] = 1.0 / i * Math.Pow(-1, p + 1);
                    p++;
                }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double P0 = 0;
            double P1 = 0;
            for (int j = 0; j < M + 1; j++)
            {
                double Tmp = Math.Pow(arg, j);
                if (j <= L)
                    P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;

            return Res;
        }

        public static string MathApprox_4_Compute_2_in()
        {
            return "(-0.5, 0.5) (-w, w)";
        }
    }

    public static class CMathApprox_5
    {
        public static string MathApprox_5_2(string PathName, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > MathApprox_5_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            //creating suitable approximation;
            //Ln_Numer is the numerator, Ln_Denom is the denominator, C is the Taylor approximation
            double[] C = new double[L + M + 1];
            C[0] = Math.PI / 2; C[1] = -1;
            for (int i = 2; i < L + M + 1; i++)
            {
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                    C[i] = C[i - 2] * (i - 2) * (i - 2) / i / (i - 1);
            }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);


            //creating program with found approximation
            string FileName = PathName + "MathApprox_5_2" + "_" + error.ToString() + ".cs";
            System.IO.StreamWriter FileWriter = CMakeProgram.MakeBeginning(PathName, "MathApprox_5_2", error);


            //!!! 
            //Необходимо заменить Ln_Numer и Ln_Denom на реально полученные коэффициенты !!!
            FileWriter.WriteLine("            double P0 = 0;");
            FileWriter.WriteLine("            double P1 = 0;");
            FileWriter.WriteLine("            double[] Denom = new double[" + (M + 1).ToString() + "];");
            FileWriter.WriteLine("            double[] Numer = new double[" + (L + 1).ToString() + "];");
            for (int i = 0; i < M + 1; i++)
                FileWriter.WriteLine("            Denom[" + i.ToString() + "] = " + Denom[i].ToString().Replace(",", ".") + ";");
            for (int i = 0; i < L + 1; i++)
                FileWriter.WriteLine("            Numer[" + i.ToString() + "] = " + Numer[i].ToString().Replace(",", ".") + ";");
            FileWriter.WriteLine("            Console.Write(\"Input argument for Acos(x): \");");
            FileWriter.WriteLine("            double arg = double.Parse(Console.ReadLine());");
            FileWriter.WriteLine("            for (int j = 0; j < " + (M + 1).ToString() + "; j++)");
            FileWriter.WriteLine("            {");
            FileWriter.WriteLine("                double Tmp = Math.Pow(arg, j);");
            FileWriter.WriteLine("                P0 += Numer[j] * Tmp;");
            FileWriter.WriteLine("                P1 += Denom[j] * Tmp;");
            FileWriter.WriteLine("            }");
            FileWriter.WriteLine("            double Res = P0 / P1;");
            FileWriter.WriteLine("            ");
            FileWriter.WriteLine("            Console.Write(\"Acos(\" + arg.ToString() + \") = \");");
            FileWriter.WriteLine("            Console.WriteLine(Res);");
            FileWriter.WriteLine("            Console.Write(\"Target value: \" + Math.Acos(arg).ToString());");
            FileWriter.WriteLine("            Console.WriteLine();");

            FileWriter.WriteLine("        }");
            FileWriter.WriteLine("    }");
            FileWriter.WriteLine("}");
            FileWriter.Close();
            return FileName;
        }

        public static double MathApprox_5_2_CheckError(int L, int M)
        {
            double[] C = new double[L + M + 1];
            C[0] = Math.PI / 2; C[1] = -1;
            for (int i = 2; i < L + M + 1; i++)
            {
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                    C[i] = C[i - 2] * (i - 2) * (i - 2) / i / (i - 1);
            }
            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];
            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double error = 0;

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                double arg = 0.001 * rnd.Next(500);
                double P0 = 0;
                double P1 = 0;
                for (int j = 0; j < M + 1; j++)
                {
                    double Tmp = Math.Pow(arg, j);
                    if (j <= L)
                        P0 += Numer[j] * Tmp;
                    P1 += Denom[j] * Tmp;
                }
                double Res = P0 / P1;

                double Temp = Math.Abs(Math.Acos(arg) - Res);
                if (error < Temp)
                    error = Temp;
            }

            return error;
        }

        public static string MathApprox_5_2_in()
        {
            return "(-0.5, 0.5) (-w, w)";
        }
    }

    /// <summary>
    /// Реализует аппроксимацию Паде функции Acos(x),
    /// где аргумент X задается параметром <paramref name="arg"/>, 
    /// а допустимая погрешность задается параметром <paramref name="error"/>
    /// Результатом функции является вещественное число Res - приближенное значение функции Acos(x)
    /// </summary>
    /// <param name="arg">Аргумент функции</param>
    /// <param name="error">Допустимая погрешность (безразмерная)<param/>
    /// <returns>Acos(x)</returns>
    [OpaqueFunction()]
    [FunctionName("MathApprox_5_Compute", "Acos(x)")]
    public static class CMathApprox_5_Compute
    {
        public static double MathApprox_5_Compute_2(double arg, double error)
        {
            int L = 1;
            int M = 1;

            //finding the appropriate L and M for the approximation to meet the adjusted error
            for (;;)
            {
                if (error > CMathApprox_5.MathApprox_5_2_CheckError(L, M))
                    break;
                M++;
                L++;
            }

            double[] C = new double[L + M + 1];
            C[0] = Math.PI / 2; C[1] = -1;
            for (int i = 2; i < L + M + 1; i++)
            {
                if ((i % 2) == 0)
                    C[i] = 0;
                else
                    C[i] = C[i - 2] * (i - 2) * (i - 2) / i / (i - 1);
            }

            double[] Numer = new double[L + 1];
            double[] Denom = new double[M + 1];

            CFind_Pade.Find_Denominator(Denom, C, L, M);
            CFind_Pade.Find_Numerator(Numer, Denom, C, L, M);

            double P0 = 0;
            double P1 = 0;
            for (int j = 0; j < M + 1; j++)
            {
                double Tmp = Math.Pow(arg, j);
                if (j <= L)
                    P0 += Numer[j] * Tmp;
                P1 += Denom[j] * Tmp;
            }
            double Res = P0 / P1;

            return Res;
        }

        public static string MathApprox_5_Compute_2_in()
        {
            return "(-0.5, 0.5) (-w, w)";
        }
    }

    public static class CFind_Pade
    {
        public static void Find_Denominator(double[] Find, double[] Taylor, int L, int M)
        {
            //initialization of the matrix
            double[,] Matrix = new double[M, M];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                    Matrix[i, j] = Taylor[L - M + (i + j + 1)];

            double[] RightMat = new double[M];
            for (int i = 0; i < M; i++)
                RightMat[i] = -Taylor[L + i + 1];
            //----------------------------------

            for (int n = 0; n < M - 1; n++)
            {
                if (Matrix[n, n] == 0)
                    for (int i = 0; i < M; i++)
                        Matrix[i, n] += Matrix[i, n + 1];
                if ((Matrix[n, n] < 0) || (Matrix[n, n] > 0))
                    break;
            }


            //solving
            for (int k = 0; k < M - 1; k++)
            {
                if (Matrix[k, k] == 0)
                    break;       
                for (int i = k + 1; i < M; i++)
                {
                    for (int j = k + 1; j < M; j++)
                        Matrix[i, j] = Matrix[i, j] - Matrix[k, j] * (Matrix[i, k] / Matrix[k, k]);

                    RightMat[i] = RightMat[i] - RightMat[k] * Matrix[i, k] / Matrix[k, k];
                }
            }
                
            double s = 0;
            for (int k = M - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < M; j++)
                    s = s + Matrix[k, j] * Find[j + 1];
                Find[k + 1] = (RightMat[k] - s) / Matrix[k, k];
            }
            for (int i = 1; i < M/2 + 1; i++)
            {
                double Tmp = Find[i];
                Find[i] = Find[M - i + 1];
                Find[M - i + 1] = Tmp;
            }
            Find[0] = 1.0;
            //----------------------------------
        }

        public static void Find_Numerator(double[] Find, double[] Denom, double[] Taylor, int L, int M)
        {
            int N = Math.Min(L, M);
            for (int i = 0; i <= L; i++)
            {
                double Tmp = 0;
                for (int k = 1; (k <= i)&&(k <= N); k++)
                {
                    Tmp += Denom[k] * Taylor[i - k];
                }
                Find[i] = Taylor[i] + Tmp;
            }
        }

    }

    public static class CMakeProgram
    {
        public static System.IO.StreamWriter MakeBeginning(string PathName, string FuncName, double error)
        {

            string Fname = PathName + FuncName + "_" + error.ToString() + ".cs";
            System.IO.StreamWriter FileWriter = new System.IO.StreamWriter(Fname);

            FileWriter.WriteLine("using System;");
            FileWriter.WriteLine("using System.Collections.Generic;");
            FileWriter.WriteLine("using System.Linq;");
            FileWriter.WriteLine("using System.Text;");
            FileWriter.WriteLine("using System.Threading.Tasks;");
            FileWriter.WriteLine();
            FileWriter.WriteLine("namespace First");
            FileWriter.WriteLine("{");
            FileWriter.WriteLine("    class Program");
            FileWriter.WriteLine("    {");
            FileWriter.WriteLine("        static void Main(string[] args)");
            FileWriter.WriteLine("        {");

            return FileWriter;
        }
    }
    
}

