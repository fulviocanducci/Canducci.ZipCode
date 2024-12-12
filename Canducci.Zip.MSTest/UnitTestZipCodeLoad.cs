using Canducci.Zip.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Canducci.Zip.MSTest
{
   [TestClass]
   public class UnitTestZipCodeLoad
   {
      public ZipCodeLoad ZipCodeLoad { get; set; }

      [TestInitialize()]
      public void Initial()
      {
         ZipCodeLoad = new ZipCodeLoad();
      }

      [TestMethod]
      public void TestZipCodeLoadFind()
      {
         ZipCodeResult zipCodeResult0 = ZipCodeLoad.Find("19206082");
         ZipCodeResult zipCodeResult1 = ZipCodeLoad.Find(ZipCode.Parse("19206082"));

         Assert.IsTrue(zipCodeResult0.IsValid);
         Assert.IsTrue(zipCodeResult1.IsValid);

         Assert.IsInstanceOfType(zipCodeResult0.Value.GetType(), typeof(ZipCodeItem).GetType());
         Assert.IsInstanceOfType(zipCodeResult1.Value.GetType(), typeof(ZipCodeItem).GetType());
      }

      [TestMethod]
      public async Task TestZipCodeLoadFindAsync()
      {
         ZipCodeResult zipCodeResult0 = await ZipCodeLoad.FindAsync("19206082");
         ZipCodeResult zipCodeResult1 = await ZipCodeLoad.FindAsync(ZipCode.Parse("19206082"));

         Assert.IsTrue(zipCodeResult0.IsValid);
         Assert.IsTrue(zipCodeResult1.IsValid);

         Assert.IsInstanceOfType(zipCodeResult0.Value.GetType(), typeof(ZipCodeItem).GetType());
         Assert.IsInstanceOfType(zipCodeResult1.Value.GetType(), typeof(ZipCodeItem).GetType());
      }

      [TestMethod]
      [ExpectedException(typeof(ZipCodeException))]
      public void TestZipCodeLoadFindException()
      {
         try
         {
            _ = ZipCodeLoad.Find("");
            _ = ZipCodeLoad.Find(ZipCode.Parse(""));
         }
         catch (ZipCodeException ex)
         {
            throw ex;
         }
      }


      [TestMethod]
      [ExpectedException(typeof(ZipCodeException))]
      public async Task TestZipCodeLoadFindAsyncException()
      {
         try
         {
            _ = await ZipCodeLoad.FindAsync("");
            _ = await ZipCodeLoad.FindAsync(ZipCode.Parse(""));
         }
         catch (ZipCodeException ex)
         {
            throw ex;
         }
      }
   }
}
