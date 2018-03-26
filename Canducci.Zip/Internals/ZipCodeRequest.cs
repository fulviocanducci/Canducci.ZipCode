using System.Collections.Generic;
using System.Text;

namespace Canducci.Zip.Internals
{
    internal class ZipCodeRequest: System.IDisposable
    {
        private IDictionary<string, string> Urls =>
             new Dictionary<string, string>
             {
                 ["zip"] = "http://viacep.com.br/ws/{0}/xml/",
                 ["address"] = "http://viacep.com.br/ws/{0}/{1}/{2}/xml/"
             };

#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
        private System.Net.WebClient Request = new System.Net.WebClient();
#elif NETSTANDARD1_3 ||  NETSTANDARD1_4 ||  NETSTANDARD1_5 ||  NETSTANDARD1_6
        private System.Net.Http.HttpClient Request = new System.Net.Http.HttpClient();
#endif

        public ZipCodeRequest()
        {
#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
            Request.Encoding = Encoding.UTF8;            
#endif
        }
#if NET40
        public string GetJsonString(string value)
        {
            return Request.DownloadString(string.Format(Urls["zip"], value));
        }
#endif
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
        public async System.Threading.Tasks.Task<string> GetJsonStringAsync(string value)
        {
            return await Request.DownloadStringTaskAsync(string.Format(Urls["zip"], value));
        }
#elif NETSTANDARD1_3 ||  NETSTANDARD1_4 ||  NETSTANDARD1_5 ||  NETSTANDARD1_6
        public async System.Threading.Tasks.Task<string> GetJsonStringAsync(string value)
        {           
            return await Request.GetStringAsync(string.Format(Urls["zip"], value));
        }
#endif
        public void Dispose()
        {
            Request.Dispose();
            Request = null;
            System.GC.SuppressFinalize(this);
        }
    }
}
