using Canducci.Zip.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Text.Json.JsonElement;

namespace Canducci.Zip.MSTest
{

   [TestClass]
   public class UnitTestRequest
   {
      internal Request Request = new Request();
      private void TestRequestZipCodeDefault(string json)
      {
         JsonDocument jsonDocument = JsonDocument.Parse(json);
         JsonElement jsonElement = jsonDocument.RootElement;

         var cep = jsonElement.GetProperty("cep").GetString();
         var logradouro = jsonElement.GetProperty("logradouro").GetString();
         var complemento = jsonElement.GetProperty("complemento").GetString();
         var bairro = jsonElement.GetProperty("bairro").GetString();
         var localidade = jsonElement.GetProperty("localidade").GetString();
         var uf = jsonElement.GetProperty("uf").GetString();
         var siafi = jsonElement.GetProperty("siafi").GetString();
         var ibge = jsonElement.GetProperty("ibge").GetString();
         var gia = jsonElement.GetProperty("gia").GetString();
         var ddd = jsonElement.GetProperty("ddd").GetString();
         var unidade = jsonElement.GetProperty("unidade").GetString();
         var estado = jsonElement.GetProperty("estado").GetString();
         var regiao = jsonElement.GetProperty("regiao").GetString();

         Assert.IsTrue(!string.IsNullOrEmpty(json));

         Assert.IsInstanceOfType(jsonDocument.GetType(), typeof(JsonDocument).GetType());
         Assert.IsInstanceOfType(jsonElement.GetType(), typeof(JsonElement).GetType());

         Assert.AreEqual("01001-000", cep);
         //Assert.AreEqual("Praça da Sé", logradouro);
         //Assert.AreEqual("lado ímpar", complemento);
         //Assert.AreEqual("Sé", bairro);
         //Assert.AreEqual("São Paulo", localidade);
         Assert.AreEqual("SP", uf);
         Assert.AreEqual("7107", siafi);
         Assert.AreEqual("11", ddd);
         Assert.AreEqual("3550308", ibge);
         Assert.AreEqual("1004", gia);

         jsonDocument.Dispose();
      }

      private void TestRequestAddressCodeDefault(string json)
      {
         JsonDocument jsonDocument = JsonDocument.Parse(json);
         JsonElement jsonElement = jsonDocument.RootElement;
         ArrayEnumerator enumerateArray = jsonElement.EnumerateArray();

         Assert.IsTrue(!string.IsNullOrEmpty(json));
         Assert.IsTrue(jsonElement.ValueKind == JsonValueKind.Array);
         Assert.IsTrue(jsonElement.GetArrayLength() > 0);

         Assert.IsInstanceOfType(jsonDocument.GetType(), typeof(JsonDocument).GetType());
         Assert.IsInstanceOfType(jsonElement.GetType(), typeof(JsonElement).GetType());
         Assert.IsInstanceOfType(enumerateArray.GetType(), typeof(ArrayEnumerator).GetType());

         jsonDocument.Dispose();
      }

      [TestMethod]
      [ExpectedException(typeof(WebException))]
      public void TestRequestZipCodeBadRequest()
      {
         try
         {
            string json = Request.GetString(new Uri("https://viacep.com.br/ws//json/"));
         }
         catch (WebException ex)
         {
            throw ex;
         }
      }

      [TestMethod]
      public void TestRequestZipCode()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/01001000/json/"));
         TestRequestZipCodeDefault(json);
      }

      [TestMethod]
      public void TestRequestZipCodeError()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/00000000/json/"));
         JsonDocument jsonDocument = JsonDocument.Parse(json);
         JsonElement jsonElement = jsonDocument.RootElement;
         string error = jsonElement.GetProperty("erro").GetString();
         Assert.IsTrue(error == "true");
      }

      [TestMethod]
      public async Task TestRequestZipCodeAsync()
      {
         string json = await Request.GetStringAsync(new Uri("https://viacep.com.br/ws/01001000/json/"));
         TestRequestZipCodeDefault(json);
      }

      [TestMethod]
      public async Task TestRequestZipCodeErrorAsync()
      {
         string json = await Request.GetStringAsync(new Uri("https://viacep.com.br/ws/00000000/json/"));
         JsonDocument jsonDocument = JsonDocument.Parse(json);
         JsonElement jsonElement = jsonDocument.RootElement;
         string error = jsonElement.GetProperty("erro").GetString();
         Assert.IsTrue(error == "true");
      }

      [TestMethod]
      public void TestRequestAddressCode()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/RS/Porto%20Alegre/Domingos/json/"));
         TestRequestAddressCodeDefault(json);
      }


      [TestMethod]
      [ExpectedException(typeof(WebException))]
      public void TestRequestAddressCodeBadRequest()
      {
         try
         {
            string json = Request.GetString(new Uri("https://viacep.com.br/ws//Porto%20Alegre/Domingos+Jose/json/"));
         }
         catch (WebException ex)
         {
            throw ex;
         }
      }


      [TestMethod]
      public void TestRequestAddressCodeEmpty()
      {
         string json = Request.GetString(new Uri("https://viacep.com.br/ws/RS/Porto%20Alegre/Dommmm/json/"));
         JsonDocument jsonDocument = JsonDocument.Parse(json);
         Assert.IsTrue(jsonDocument.RootElement.GetArrayLength() == 0);
      }

      [TestMethod]
      public async Task TestRequestAddressCodeAsync()
      {
         string json = await Request.GetStringAsync(new Uri("https://viacep.com.br/ws/RS/Porto%20Alegre/Domingos/json/"));
         TestRequestAddressCodeDefault(json);
      }

      [TestMethod]
      public async Task TestRequestAddressCodeEmptyAsync()
      {
         string json = await Request.GetStringAsync(new Uri("https://viacep.com.br/ws/RS/Porto%20Alegre/Dommmm/json/"));
         JsonDocument jsonDocument = JsonDocument.Parse(json);
         Assert.IsTrue(jsonDocument.RootElement.GetArrayLength() == 0);
      }
   }
}