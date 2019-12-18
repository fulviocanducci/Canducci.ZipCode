using Microsoft.VisualStudio.TestTools.UnitTesting;
using Canducci.Zip.Internals;
using System;

namespace Canducci.Zip.MSTest
{
   [TestClass]
   public class UnitTestDeserialize
   {
      internal Request Request = new Request();
      internal Deserialize Deserialize = new Deserialize();

      [TestMethod]
      public void TestDeserializeZipCode()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/01001000/json/"));
         ZipCodeItem zipCodeItem = Deserialize.ConvertTo<ZipCodeItem>(json);
         ZipCodeResult zipCodeResult = new ZipCodeResult(zipCodeItem);         

         Assert.IsInstanceOfType(zipCodeItem.GetType(), typeof(ZipCodeItem).GetType());
         Assert.IsTrue(zipCodeResult);
         Assert.IsTrue(zipCodeResult.IsValid);
      }

      [TestMethod]
      public void TestDeserializeZipCodeNoValid()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/00000000/json/"));
         ZipCodeItem zipCodeItem = Deserialize.ConvertTo<ZipCodeItem>(json);
         ZipCodeResult zipCodeResult = new ZipCodeResult(zipCodeItem);

         Assert.IsInstanceOfType(zipCodeItem.GetType(), typeof(ZipCodeItem).GetType());
         Assert.IsInstanceOfType(zipCodeResult.GetType(), typeof(ZipCodeResult).GetType());
         Assert.IsFalse(zipCodeResult);
         Assert.IsFalse(zipCodeResult.IsValid);
      }

      [TestMethod]
      public void TestDeserializeAddressCode()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/RS/Porto%20Alegre/Domingos/json/"));
         AddressCodeItem addressCodeItem = Deserialize.ConvertTo<AddressCodeItem>(json);
         AddressCodeResult addressCodeResult = new AddressCodeResult(addressCodeItem);

         Assert.IsInstanceOfType(addressCodeItem.GetType(), typeof(AddressCodeItem).GetType());
         Assert.IsInstanceOfType(addressCodeResult.GetType(), typeof(AddressCodeResult).GetType());
         Assert.IsTrue(addressCodeResult);
         Assert.IsTrue(addressCodeResult.IsValid);
      }

      [TestMethod]
      public void TestDeserializeAddressCodeNoValid()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/RS/Porto%20Alegre/Dommmm/json/"));
         AddressCodeItem addressCodeItem = Deserialize.ConvertTo<AddressCodeItem>(json);
         AddressCodeResult addressCodeResult = new AddressCodeResult(addressCodeItem);

         Assert.IsInstanceOfType(addressCodeItem.GetType(), typeof(AddressCodeItem).GetType());
         Assert.IsInstanceOfType(addressCodeResult.GetType(), typeof(AddressCodeResult).GetType());
         Assert.IsFalse(addressCodeResult);
         Assert.IsFalse(addressCodeResult.IsValid);
      }
   }
}
