using System.Text.Json.Serialization;

namespace Canducci.Zip
{
   public class ZipCodeItem
   {
      [JsonPropertyName("cep")]
      public string Zip { get; set; }

      [JsonPropertyName("logradouro")]
      public string Address { get; set; }

      [JsonPropertyName("complemento")]
      public string Complement { get; set; }

      [JsonPropertyName("bairro")]
      public string District { get; set; }

      [JsonPropertyName("localidade")]
      public string City { get; set; }

      [JsonPropertyName("uf")]
      public string Uf { get; set; }

      [JsonPropertyName("ibge")]
      public string Ibge { get; set; }

      [JsonPropertyName("gia")]
      public string Gia { get; set; }

      [JsonPropertyName("ddd")]
      public string Ddd { get; set; }

      [JsonPropertyName("siafi")]
      public string Siafi { get; set; }

      [JsonPropertyName("unidade")]
      public string Unity { get; set; }

      [JsonPropertyName("estado")]
      public string State { get; set; }

      [JsonPropertyName("regiao")]
      public string Region { get; set; }
   }
}