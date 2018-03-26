﻿namespace Canducci.Zip
{
    public sealed class ZipCodeItem
    {
        public ZipCodeItem(string zip, 
            string address,
            string district,
            string city,
            string uf,
            int ibge,
            bool erro, 
            string complement,
            string gia)
        {
            Zip = zip;
            Address = address;
            District = district;
            City = city;
            Uf = uf;
            Ibge = ibge;
            Erro = erro;
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

        [Newtonsoft.Json.JsonProperty("erro")]
        public bool Erro { get; }

        [Newtonsoft.Json.JsonProperty("complemento")]
        public string Complement { get; }

        [Newtonsoft.Json.JsonProperty("gia")]
        public string Gia { get; }
    }
}

/*
 * {
      "cep": "01001-000",
      "logradouro": "Praça da Sé",
      "complemento": "lado ímpar",
      "bairro": "Sé",
      "localidade": "São Paulo",
      "uf": "SP",
      "unidade": "",
      "ibge": "3550308",
      "gia": "1004"
    }
    **/