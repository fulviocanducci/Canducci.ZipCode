namespace Canducci.Zip.Internals
{
    internal class ZipCodeRequest: System.IDisposable
    {
        internal System.Collections.Generic.IDictionary<string, string> Urls =>
             new System.Collections.Generic.Dictionary<string, string>
             {
                 ["zip"] = "http://viacep.com.br/ws/{0}/json/",
                 ["address"] = "http://viacep.com.br/ws/{0}/{1}/{2}/json/"
             };

#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
        internal System.Net.WebClient Request = new System.Net.WebClient();
#elif NETSTANDARD1_3 ||  NETSTANDARD1_4 ||  NETSTANDARD1_5 ||  NETSTANDARD1_6
        internal System.Net.Http.HttpClient Request = new System.Net.Http.HttpClient();
#endif
        public ZipCodeRequest()
        {
#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
            Request.Encoding = System.Text.Encoding.UTF8;            
#endif
        }
#if NET40
        internal string GetJsonString(string value, string key = "zip")
        {
            return Request.DownloadString(string.Format(Urls[key], value));
        }
#endif
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync(string value, string key = "zip")
        {
            return await Request.DownloadStringTaskAsync(string.Format(Urls[key], value));
        }
#elif NETSTANDARD1_3 ||  NETSTANDARD1_4 ||  NETSTANDARD1_5 ||  NETSTANDARD1_6
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync(string value, string key = "zip")
        {           
            return await Request.GetStringAsync(string.Format(Urls[key], value));
        }
#endif
        public void Dispose()
        {
            Request.Dispose();
            Request = null;
            System.GC.SuppressFinalize(this);
        }

        internal static ZipCodeRequest Create() => new ZipCodeRequest();
    }
}
