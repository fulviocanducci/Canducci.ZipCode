namespace Canducci.Zip
{
    public sealed class AddressCode
    {        
        public ZipCodeUf Uf { get; private set; }        
        public string City { get; private set; }        
        public string Address { get; private set; }

        public AddressCode(ZipCodeUf uf, string city, string address)
        {
            Uf = uf;
            City = city;
            Address = address;
        }

        internal static bool Valid(string uf, string city, string address)
        {
            return (uf.Length == 2 && city.Length > 2 && address.Length > 2);
        }

        public static AddressCode Parse(ZipCodeUf uf, string city, string address)
        {
            if (Valid(uf.ToString(), city, address))
            {
                return new AddressCode(uf, city, address);
            }
            throw new ZipCodeException("UF length is 2 letters and City and Address length more than 2 letters", 
                new System.FormatException());
        }

        public static bool TryParse(ZipCodeUf uf, string city, string address, out AddressCode addressCode)
        {
            if (Valid(uf.ToString(), city, address))
            {
                addressCode = new AddressCode(uf, city, address);             
                return true;
            }
            addressCode = null;
            return false;
        }
    }
}
