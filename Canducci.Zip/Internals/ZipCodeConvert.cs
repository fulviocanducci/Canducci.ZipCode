namespace Canducci.Zip.Internals
{
    internal class ZipCodeConvert : System.IDisposable
    {
        internal ZipCodeConvert() { }

        internal T ConvertTo<T>(string value)
        {
            return (T)Newtonsoft.Json.JsonConvert.DeserializeObject(value, typeof(T));
        }

        internal ZipCodeItem ConvertZipCodeItem(string value)
        {
            return ConvertTo<ZipCodeItem>(value);
        }

        internal AddressCodeItem ConvertZipCodeItems(string value)
        {
            return ConvertTo<AddressCodeItem>(value);
        }

        internal Validations.ZipCodeItemValid ConvertZipCodeItemValid(string value)
        {
            return ConvertTo<Validations.ZipCodeItemValid>(value);
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        internal static ZipCodeConvert Create() 
            => new ZipCodeConvert();

    }
}
