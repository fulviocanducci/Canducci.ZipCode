namespace Canducci.Zip
{
    public class ZipCodeItem
    {
        [Newtonsoft.Json.JsonConstructor()]
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

        [Newtonsoft.Json.JsonProperty("cep")]
        public string Zip { get; }

        [Newtonsoft.Json.JsonProperty("logradouro")]
        public string Address { get; }

        [Newtonsoft.Json.JsonProperty("bairro")]
        public string District { get; }

        [Newtonsoft.Json.JsonProperty("localidade")]
        public string City { get; }

        [Newtonsoft.Json.JsonProperty("uf")]
        public string Uf { get; }

        [Newtonsoft.Json.JsonProperty("ibge")]
        public int Ibge { get; }        

        [Newtonsoft.Json.JsonProperty("complemento")]
        public string Complement { get; }

        [Newtonsoft.Json.JsonProperty("gia")]
        public string Gia { get; }
    }
}