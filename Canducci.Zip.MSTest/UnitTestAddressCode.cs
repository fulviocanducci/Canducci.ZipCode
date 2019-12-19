using Canducci.Zip.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canducci.Zip.MSTest
{
   [TestClass]
   public class UnitTestAddressCode
   {
      [TestMethod]
      public void TestTestAddressCode()
      {
         AddressCode addressCode = new AddressCode(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA");
         Assert.AreEqual(ZipCodeUf.SP, addressCode.Uf);
         Assert.AreEqual("SÃO PAULO", addressCode.City);
         Assert.AreEqual("AVENIDA", addressCode.Address);
         Assert.IsInstanceOfType(addressCode.GetType(), typeof(AddressCode).GetType());
      }


      [TestMethod]
      public void TestTestAddressCodeParse()
      {
         AddressCode addressCode = AddressCode.Parse(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA");
         Assert.AreEqual(ZipCodeUf.SP, addressCode.Uf);
         Assert.AreEqual("SÃO PAULO", addressCode.City);
         Assert.AreEqual("AVENIDA", addressCode.Address);
         Assert.IsInstanceOfType(addressCode.GetType(), typeof(AddressCode).GetType());

      }

      [TestMethod]
      [ExpectedException(typeof(AddressCodeException))]
      public void TestTestAddressCodeParseException()
      {
         AddressCode.Parse(ZipCodeUf.SP, "", "");
      }

      [TestMethod]
      public void TestTestAddressCodeTryParse()
      {
         bool result = AddressCode
            .TryParse(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA", out AddressCode addressCode);
         Assert.AreEqual(ZipCodeUf.SP, addressCode.Uf);
         Assert.AreEqual("SÃO PAULO", addressCode.City);
         Assert.AreEqual("AVENIDA", addressCode.Address);
         Assert.IsTrue(result);
         Assert.IsInstanceOfType(addressCode.GetType(), typeof(AddressCode).GetType());
      }

      [TestMethod]
      public void TestTestAddressCodeTryParseFalse()
      {
         bool result = AddressCode
            .TryParse(ZipCodeUf.SP, "", "", out AddressCode addressCode);         
         Assert.IsFalse(result);
         Assert.IsNull(addressCode);
      }
   }
}
