namespace Canducci.Zip.Internals
{
    internal class ZipCodeConvert : System.IDisposable
    {
        public ZipCodeConvert() { }

        internal T Convert<T>(string value)
        {
            return (T)Newtonsoft.Json.JsonConvert.DeserializeObject(value, typeof(T));
        }

        internal dynamic Convert(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(value);
        }

        internal ZipCodeItem ConvertZipCodeItem(string value)
        {
            return Convert<ZipCodeItem>(value);
        }

        internal AddressCodeItem ConvertZipCodeItems(string value)
        {
            return Convert<AddressCodeItem>(value);
        }

        internal Validations.ZipCodeItemValid ConvertZipCodeItemValid(string value)
        {
            return Convert<Validations.ZipCodeItemValid>(value);
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        internal static ZipCodeConvert Create() 
            => new ZipCodeConvert();

    }
}
