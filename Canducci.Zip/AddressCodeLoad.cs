namespace Canducci.Zip
{
    /// <summary>
    /// AddressCodeLoad Class
    /// </summary>
    public sealed class AddressCodeLoad
    {
        internal Internals.ZipCodeConvert Convert;
        internal Internals.ZipCodeRequest Request;

        public AddressCodeLoad()
        {
            Convert = Internals.ZipCodeConvert.Create(); 
            Request = Internals.ZipCodeRequest.Create();
        }

        private AddressCodeResult GetAddressCodeResult(string json)
        {
            AddressCodeItem values = Convert.ConvertZipCodeItems(json);
            return new AddressCodeResult(values);
        }

#if NET40
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="value">AddressCode class</param>
        /// <returns>AddressCodeResult class</returns>
        public AddressCodeResult Find(AddressCode value)
        {
            string json = Request.GetJsonString(value.Uf.ToString(), value.City, value.Address);
            return GetAddressCodeResult(json);
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="uf">ZipCodeUf enum</param>
        /// <param name="city">string</param>
        /// <param name="address">string</param>
        /// <returns>AddressCodeResult class</returns>
        public AddressCodeResult Find(ZipCodeUf uf, string city, string address)
        {
            return Find(AddressCode.Parse(uf, city, address));
        }
#else
        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="value">AddressCode class</param>
        /// <returns>AddressCodeResult</returns>
        public async System.Threading.Tasks.Task<AddressCodeResult> FindAsync(AddressCode value)
        {
            string json = await Request.GetJsonStringAsync(value.Uf.ToString(), value.City, value.Address);
            return GetAddressCodeResult(json);
        }
        /// <summary>
        /// FindAsync
        /// </summary>
        /// <param name="uf">ZipCodeUf enum</param>
        /// <param name="city">string</param>
        /// <param name="address">string</param>
        /// <returns>AddressCodeResult class</returns>
        public async System.Threading.Tasks.Task<AddressCodeResult> FindAsync(ZipCodeUf uf, string city, string address)
        {
            return await FindAsync(AddressCode.Parse(uf, city, address));
        }
#endif
        public void Dispose()
        {
            Convert?.Dispose();
            Request?.Dispose();
        }
    }
}
