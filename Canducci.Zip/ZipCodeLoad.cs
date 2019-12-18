using Canducci.Zip.Exceptions;
using Canducci.Zip.Interfaces;
using Canducci.Zip.Internals;
using System;
using System.Threading.Tasks;

namespace Canducci.Zip
{
   public class ZipCodeLoad : IZipCodeLoad
   {
      internal readonly Deserialize Deserialize;
      internal readonly Request Request;
      internal const string Url = "http://viacep.com.br/ws/{0}/json/";

      public ZipCodeLoad()
      {
         Deserialize = new Deserialize();
         Request = new Request();
      }

      private Uri GetCreateUrl(ZipCode zipCode)
      {
         return new Uri(string.Format(Url, zipCode.Value));
      }

      private ZipCodeResult GetConvertResult(string json)
      {
         ZipCodeItem value = Deserialize.ConvertTo<ZipCodeItem>(json);
         return new ZipCodeResult(true, value);
      }

      public ZipCodeResult Find(ZipCode value)
      {
         string json = Request.GetString(GetCreateUrl(value));
         return GetConvertResult(json);
      }

      public ZipCodeResult Find(string value)
      {
         if (ZipCode.TryParse(value, out ZipCode zipCode))
         {
            return Find(zipCode);
         }
         throw new ZipCodeException();
      }

      public async Task<ZipCodeResult> FindAsync(ZipCode value)
      {
         string json = await Request.GetStringAsync(GetCreateUrl(value));
         return GetConvertResult(json);
      }

      public async Task<ZipCodeResult> FindAsync(string value)
      {
         if (ZipCode.TryParse(value, out ZipCode zipCode))
         {
            return await FindAsync(zipCode);
         }
         throw new ZipCodeException();
      }

      public void Dispose()
      {
         Deserialize?.Dispose();
         Request?.Dispose();
      }
   }
}
