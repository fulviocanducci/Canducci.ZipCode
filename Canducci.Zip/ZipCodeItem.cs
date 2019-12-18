using System.Text.Json.Serialization;

namespace Canducci.Zip
{
   public class ZipCodeItem
   {      
      internal ZipCodeItem(string zip,
          string address,
          string district,
          string city,
          string uf,
          int ibge,
          string complement,
          string gia)
      {
         Zip = zip;
         Address = address;
         District = district;
         City = city;
         Uf = uf;
         Ibge = ibge;
         Complement = complement;
         Gia = gia;
      }

      [JsonPropertyName("cep")]
      public string Zip { get; }

      [JsonPropertyName("logradouro")]
      public string Address { get; }

      [JsonPropertyName("bairro")]
      public string District { get; }

      [JsonPropertyName("localidade")]
      public string City { get; }

      [JsonPropertyName("uf")]
      public string Uf { get; }

      [JsonPropertyName("ibge")]
      public int Ibge { get; }

      [JsonPropertyName("complemento")]
      public string Complement { get; }

      [JsonPropertyName("gia")]
      public string Gia { get; }
   }
}