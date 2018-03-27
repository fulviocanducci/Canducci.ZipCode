namespace Canducci.Zip
{
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
            Validations.ZipCodeItemValid valid = Convert.ConvertZipCodeItemValid(json);
            if (valid.Erro)
            {
                return new AddressCodeResult(false);
            }
            return new AddressCodeResult(true, Convert.ConvertZipCodeItems(json));
        }

#if NET40
        public AddressCodeResult Find(AddressCode value)
        {
            string json = Request.GetJsonString(value.Uf.ToString(), value.City, value.Address);
            return GetAddressCodeResult(json);
        }

#else
        public async System.Threading.Tasks.Task<AddressCodeResult> FindAsync(AddressCode value)
        {
            string json = await Request.GetJsonStringAsync(value.Uf.ToString(), value.City, value.Address);
            return GetAddressCodeResult(json);
        }
#endif
        public void Dispose()
        {
            Convert?.Dispose();
            Request?.Dispose();
        }
    }
}
