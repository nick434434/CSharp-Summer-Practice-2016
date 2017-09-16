using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpaqueFunctions;

namespace ModuleTests
{

    [TestClass]
    public class TMathApprox_1
    {
        [TestMethod]
        public void MathApprox_1_Compute_2_Test()
        {
            Random rnd = new Random();
            double error = 0.000000005;
            for (int i = 0; i < 1000; i++)
            {
                double arg = rnd.Next(1, 2000) - 1000;
                arg = arg / 2000.0;
                Assert.IsTrue((Math.Abs(CMathApprox_1_Compute.MathApprox_1_Compute_2(arg, error)
                    - Math.Log(1 + arg)) < error), "Значение недостаточно близко к реальному");
            }
        }
    }

    [TestClass]
    public class TMathApprox_2
    {
        [TestMethod]
        public void MathApprox_2_Compute_2_Test()
        {
            Random rnd = new Random();
            double error = 0.000000005;
            for (int i = 0; i < 1000; i++)
            {
                double arg = rnd.Next(1, 4000) - 2000;
                arg = arg / 2000.0;
                Assert.IsTrue((Math.Abs(CMathApprox_2_Compute.MathApprox_2_Compute_2(arg, error)
                    - Math.Atan(arg)) < error), "Значение недостаточно близко к реальному");
            }
        }
    }

    [TestClass]
    public class TMathApprox_3
    {
        [TestMethod]
        public void MathApprox_3_Compute_2_Test()
        {
            Random rnd = new Random();
            double error = 0.000000005;
            for (int i = 0; i < 1000; i++)
            {
                double arg = rnd.Next(1, 2000) - 1000;
                arg = arg / 2000.0;
                Assert.IsTrue((Math.Abs(CMathApprox_3_Compute.MathApprox_3_Compute_2(arg, error)
                    - Math.Asin(arg)) < error), "Значение недостаточно близко к реальному");
            }
        }
    }

    [TestClass]
    public class TMathApprox_4
    {
        [TestMethod]
        public void MathApprox_4_Compute_2_Test()
        {
            Random rnd = new Random();
            double error = 0.000000005;
            for (int i = 0; i < 1000; i++)
            {
                double arg = rnd.Next(1, 2000) - 1000;
                arg = arg / 2000.0;
                Assert.IsTrue((Math.Abs(CMathApprox_4_Compute.MathApprox_4_Compute_2(arg, error)
                    -Math.PI / 2 + Math.Atan(arg)) < error), "Значение недостаточно близко к реальному");
            }
        }
    }

    [TestClass]
    public class TMathApprox_5
    {
        [TestMethod]
        public void MathApprox_5_Compute_2_Test()
        {
            Random rnd = new Random();
            double error = 0.000000005;
            for (int i = 0; i < 1000; i++)
            {
                double arg = rnd.Next(1, 2000) - 1000;
                arg = arg / 2000.0;
                Assert.IsTrue((Math.Abs(CMathApprox_5_Compute.MathApprox_5_Compute_2(arg, error)
                    - Math.Acos(arg)) < error), "Значение недостаточно близко к реальному");
            }
        }
    }
}
