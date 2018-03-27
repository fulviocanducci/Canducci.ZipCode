using System;

namespace Canducci.Zip
{
    public class ZipCodeLoad : System.IDisposable
    {
        internal Internals.ZipCodeConvert Convert;
        internal Internals.ZipCodeRequest Request;

        public ZipCodeLoad()
        {
            Convert = Internals.ZipCodeConvert.Create();
            Request = Internals.ZipCodeRequest.Create();
        }

        private ZipCodeResult GetZipCodeResult(string json)
        {
            Validations.ZipCodeItemValid valid = Convert.ConvertZipCodeItemValid(json);
            if (valid.Erro)
                return new ZipCodeResult(false);
            return new ZipCodeResult(true, Convert.ConvertZipCodeItem(json));
        }

#if NET40
        public ZipCodeResult Find(ZipCode value)
        {            
            string json = Request.GetJsonString(value);
            return GetZipCodeResult(json);
        }

#else
        public async System.Threading.Tasks.Task<ZipCodeResult> FindAsync(ZipCode value)
        {
            string json = await Request.GetJsonStringAsync(value);
            return GetZipCodeResult(json);
        }
#endif
        public void Dispose()
        {
            Convert?.Dispose();
            Request?.Dispose();
        }
    }
}
