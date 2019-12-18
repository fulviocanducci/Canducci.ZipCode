using Canducci.Zip.Interfaces;
using Canducci.Zip.Internals;
using Canducci.Zip.Exceptions;
using System;
using System.Threading.Tasks;
namespace Canducci.Zip
{
   public sealed class AddressCodeLoad : IAddressCodeLoad
   {
      internal readonly Deserialize Deserialize;
      internal readonly Request Request;
      internal const string Url = "http://viacep.com.br/ws/{0}/{1}/{2}/json/";
      public AddressCodeLoad()
      {
         Deserialize = new Deserialize();
         Request = new Request();
      }

      private Uri GetCreateUrl(AddressCode value)
      {
         return new Uri(string.Format(Url, value.Uf.ToString(), value.City, value.Address));
      }

      private AddressCodeResult GetConvertResult(string json)
      {
         AddressCodeItem values = Deserialize.ConvertTo<AddressCodeItem>(json);
         return new AddressCodeResult(values);
      }

      public AddressCodeResult Find(AddressCode value)
      {
         string json = Request.GetString(GetCreateUrl(value));
         return GetConvertResult(json);
      }

      public AddressCodeResult Find(ZipCodeUf uf, string city, string address)
      {
         if (AddressCode.TryParse(uf, city, address, out AddressCode addressCode))
         {
            return Find(addressCode);
         }
         throw new AddressCodeException();
      }

      public async Task<AddressCodeResult> FindAsync(AddressCode value)
      {
         string json = await Request.GetStringAsync(GetCreateUrl(value));
         return GetConvertResult(json);
      }

      public async Task<AddressCodeResult> FindAsync(ZipCodeUf uf, string city, string address)
      {
         if (AddressCode.TryParse(uf, city, address, out AddressCode addressCode))
         {
            return await FindAsync(addressCode);
         }
         throw new AddressCodeException();
      }

      public void Dispose()
      {
         Deserialize?.Dispose();
         Request?.Dispose();
      }
   }
}
