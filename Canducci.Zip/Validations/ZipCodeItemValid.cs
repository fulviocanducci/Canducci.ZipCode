using System.Text.Json.Serialization;

namespace Canducci.Zip.Validations
{
    internal class ZipCodeItemValid
    {
        [JsonPropertyName("erro")]
        public bool Erro { get; set; }
    }
}
