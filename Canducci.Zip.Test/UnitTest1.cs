using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Canducci.Zip;
namespace Canducci.Zip.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInstanceZipCodeParse()
        {
            var zipCode = ZipCode.Parse("01000-000");
            Assert.IsInstanceOfType(zipCode, typeof(ZipCode));
            Assert.AreEqual("01000000", zipCode.Zip);
        }

        [TestMethod]
        public void TestInstanceZipCodeTryParse()
        {
            Assert.IsTrue(ZipCode.TryParse("01000-000", out ZipCode zipCode));
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
    }
}
