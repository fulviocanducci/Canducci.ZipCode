using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Canducci.Zip.Test
{
    [TestClass]
    public class UnitTest1
    {
        public const string ValueZip = "01001000";

        [TestMethod]
        public void TestInstanceZipCodeParse()
        {
            var zipCode = ZipCode.Parse(ValueZip);
            Assert.IsInstanceOfType(zipCode, typeof(ZipCode));
            Assert.AreEqual(ValueZip, zipCode.Zip);
        }

        [TestMethod]
        public void TestInstanceZipCodeTryParse()
        {
            Assert.IsTrue(ZipCode.TryParse(ValueZip, out ZipCode zipCode));
            Assert.IsInstanceOfType(zipCode, typeof(ZipCode));
            Assert.IsNotNull(zipCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ZipCodeException), "Error Parse")]
        public void TestInstanceZipCodeParseException()
        {
            var zipCode = ZipCode.Parse("");
            Assert.Fail();
        }

        [TestMethod]        
        public void TestInstanceZipCodeTryParseFalse()
        {
            Assert.IsFalse(ZipCode.TryParse("", out ZipCode zipCode));
            Assert.IsNull(zipCode);
        }        

        [TestMethod]
        public void TestInstanceZipCodeLoadInstance()
        {
            var zipCodeLoad = new ZipCodeLoad();
            Assert.IsInstanceOfType(zipCodeLoad, typeof(ZipCodeLoad));
        }

        [TestMethod]
        public void TestInstanceZipCodeExplicitImplictConvert()
        {
            ZipCode zipCode = ValueZip;            
            string value = zipCode;

            Assert.IsInstanceOfType(zipCode, typeof(ZipCode));
            Assert.IsInstanceOfType(value, typeof(string));
            Assert.AreEqual(zipCode.Zip, value);
            Assert.AreNotEqual(zipCode, value);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestInstanceZipCodeLoadAndZipCodeResultAndZipCodeItemSuccess()
        {
            ZipCodeLoad zipCodeLoad = new ZipCodeLoad();
            ZipCodeResult zipCodeResult = await zipCodeLoad.FindAsync(ValueZip);
            Assert.IsInstanceOfType(zipCodeLoad, typeof(ZipCodeLoad));
            Assert.IsInstanceOfType(zipCodeResult, typeof(ZipCodeResult));
            Assert.IsInstanceOfType(zipCodeResult.Value, typeof(ZipCodeItem));
            Assert.IsTrue(zipCodeResult.IsValid);
        }

        [TestMethod]
        [ExpectedException(typeof(ZipCodeException), "Error Parse")]
        public async System.Threading.Tasks.Task TestInstanceZipCodeLoadAndZipCodeResultAndZipCodeItemError()
        {
            ZipCodeLoad zipCodeLoad = new ZipCodeLoad();
            ZipCodeResult zipCodeResult = await zipCodeLoad.FindAsync("");            
            Assert.Fail();
        }

    }
}
