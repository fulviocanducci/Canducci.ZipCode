using Canducci.Zip.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canducci.Zip.MSTest
{
   [TestClass]
   public class UnitTestAddressCodeLoad
   {
      public AddressCodeLoad AddressCodeLoad { get; set; }
      [TestInitialize]
      public void Initial()
      {
         AddressCodeLoad = new AddressCodeLoad();
      }
      [TestMethod]
      public void TestAddressCodeLoadFind()
      {
         AddressCodeResult addressCodeResult =
            AddressCodeLoad.Find(new AddressCode(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA"));
         AddressCodeItem value = addressCodeResult.Value;
         Assert.IsTrue(addressCodeResult.IsValid);
         Assert.IsNotNull(value);
         Assert.IsInstanceOfType(value.GetType(), typeof(AddressCodeItem).GetType());
         Assert.IsInstanceOfType(value.GetType(), typeof(List<ZipCodeItem>).GetType());
      }

      [TestMethod]
      public async Task TestAddressCodeLoadFindAsync()
      {
         AddressCodeResult addressCodeResult = await
            AddressCodeLoad.FindAsync(new AddressCode(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA"));
         AddressCodeItem value = addressCodeResult.Value;
         Assert.IsTrue(addressCodeResult.IsValid);
         Assert.IsNotNull(value);
         Assert.IsInstanceOfType(value.GetType(), typeof(AddressCodeItem).GetType());
         Assert.IsInstanceOfType(value.GetType(), typeof(List<ZipCodeItem>).GetType());
      }


      [TestMethod]
      [ExpectedException(typeof(AddressCodeException))]
      public void TestAddressCodeLoadFindException()
      {
         try
         {
            AddressCodeLoad.Find(AddressCode.Parse(ZipCodeUf.SP, "", ""));
         }
         catch (AddressCodeException ex)
         {
            throw ex;
         }
      }

      [TestMethod]
      [ExpectedException(typeof(AddressCodeException))]
      public async Task TestAddressCodeLoadFindAsyncException()
      {
         try
         {
            await AddressCodeLoad.FindAsync(AddressCode.Parse(ZipCodeUf.SP, "", ""));
         }
         catch (AddressCodeException ex)
         {
            throw ex;
         }

      }

      [TestMethod]
      public void TestAddressCodeLoadFindArgument()
      {
         AddressCodeResult addressCodeResult =
            AddressCodeLoad.Find(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA");
         AddressCodeItem value = addressCodeResult.Value;
         Assert.IsTrue(addressCodeResult.IsValid);
         Assert.IsNotNull(value);
         Assert.IsInstanceOfType(value.GetType(), typeof(AddressCodeItem).GetType());
         Assert.IsInstanceOfType(value.GetType(), typeof(List<ZipCodeItem>).GetType());
      }

      [TestMethod]
      public async Task TestAddressCodeLoadFindAsyncArgument()
      {
         AddressCodeResult addressCodeResult = await
            AddressCodeLoad.FindAsync(ZipCodeUf.SP, "SÃO PAULO", "AVENIDA");
         AddressCodeItem value = addressCodeResult.Value;
         Assert.IsTrue(addressCodeResult.IsValid);
         Assert.IsNotNull(value);
         Assert.IsInstanceOfType(value.GetType(), typeof(AddressCodeItem).GetType());
         Assert.IsInstanceOfType(value.GetType(), typeof(List<ZipCodeItem>).GetType());
      }

      [TestMethod]
      [ExpectedException(typeof(AddressCodeException))]
      public void TestAddressCodeLoadFindArgumentException()
      {
         AddressCodeLoad.Find(ZipCodeUf.SP, "", "");
      }

      [TestMethod]
      [ExpectedException(typeof(AddressCodeException))]
      public async Task TestAddressCodeLoadFindAsyncArgumentException()
      {
         await AddressCodeLoad.FindAsync(ZipCodeUf.SP, "", "");
      }
   }
}
