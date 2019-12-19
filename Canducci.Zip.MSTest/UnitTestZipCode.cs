using Canducci.Zip.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canducci.Zip.MSTest
{
   [TestClass]
   public class UnitTestZipCode
   {
      [TestMethod]
      public void TestZipCodeParse()
      {
         ZipCode zipCode = ZipCode.Parse("19200000");
         Assert.IsInstanceOfType(zipCode.GetType(), typeof(ZipCode).GetType());
         Assert.AreEqual(zipCode.Value, "19200000");
      }

      [TestMethod]
      public void TestZipCodeTryParse()
      {
         if (ZipCode.TryParse("19200000", out ZipCode zipCode))
         {
            Assert.IsInstanceOfType(zipCode.GetType(), typeof(ZipCode).GetType());
            Assert.AreEqual(zipCode.Value, "19200000");
         }
      }

      [TestMethod]
      [ExpectedException(typeof(ZipCodeException))]
      public void TestZipCodeParseException()
      {
         try
         {
            _ = ZipCode.Parse("");
         }
         catch (System.Exception)
         {
            throw;
         }
      }

      [TestMethod]
      public void TestZipCodeTryParseNoParse()
      {
         bool result = ZipCode.TryParse("", out ZipCode zipCode);
         Assert.IsNull(zipCode);
         Assert.IsFalse(result);
      }
   }
}
