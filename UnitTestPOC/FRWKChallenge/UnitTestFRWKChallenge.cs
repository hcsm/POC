using Domain.Entity.FRWK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using Utilities;

namespace UnitTestPOC
{
    [TestClass]
    public class UnitTestFRWKChallenge
    {
        #region Performance

        [TestMethod]
        public void TestUtilitesDecomposeNumber_Performance()
        {
            FRWKChallenge obj = null;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            obj = Utilites.DecomposeNumberMethod1(720);
            sw.Stop();
            var time1 = sw.Elapsed;

            sw.Reset();
            sw.Start();
            obj = Utilites.DecomposeNumberMethod2(720);
            sw.Stop();
            var time2 = sw.Elapsed;

            Assert.IsTrue(time1 > time2, "DecomposeNumberMethod2 é mais eficiente que DecomposeNumberMethod1");
        }

        [TestMethod]
        public void TestUtilitesDecomposeNumber_Equality()
        {
            FRWKChallenge obj = Utilites.DecomposeNumberMethod1(720);
            FRWKChallenge obj2 = Utilites.DecomposeNumberMethod2(720);

            Assert.IsTrue((obj.lstDivisors.All(obj2.lstDivisors.Contains) && obj.lstPrimeNumbers.All(obj2.lstPrimeNumbers.Contains) && obj.number == obj2.number), "Objetos são diferentes.");
        }
        #endregion
        #region Validations
        [TestMethod]
        [ExpectedException(typeof(Exception), "Somente número natural positivo menor que 2147483648, diferente de zero, é permitido.")]
        public void TestUtilitesDecomposeNumber_InvalidNumber_ResultException()
        {
            FRWKChallenge obj = Utilites.DecomposeNumberMethod2(-14);
        }

        [TestMethod]
        public void TestUtilitesDecomposeNumber_ValidNumber_ResultInstanceOf()
        {
            FRWKChallenge obj = Utilites.DecomposeNumberMethod2(720);
            Assert.IsInstanceOfType(obj, typeof(FRWKChallenge));
        }
        #endregion
    }
}
