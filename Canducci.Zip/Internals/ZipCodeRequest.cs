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
        internal ZipCodeRequest()
        {
#if NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
            Request.Encoding = System.Text.Encoding.UTF8;
#endif           
        }
#if NET40
        internal string GetJsonString(string value)
        {
            return Request.DownloadString(string.Format(Urls["zip"], value));
        }
        internal string GetJsonString(string uf, string city, string address)
        {
            return Request.DownloadString(string.Format(Urls["address"], uf, city, address));
        }
#endif
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NETSTANDARD2_0
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync(string value)
        {
            return await Request.DownloadStringTaskAsync(string.Format(Urls["zip"], value));
        }
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync(string uf, string city, string address)
        {
            return await Request.DownloadStringTaskAsync(string.Format(Urls["address"], uf, city, address));
        }
#elif NETSTANDARD1_3 ||  NETSTANDARD1_4 ||  NETSTANDARD1_5 ||  NETSTANDARD1_6
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync(string value)
        {           
            return await Request.GetStringAsync(string.Format(Urls["zip"], value));
        }
        internal async System.Threading.Tasks.Task<string> GetJsonStringAsync(string uf, string city, string address)
        {
            return await Request.GetStringAsync(string.Format(Urls["address"], uf, city, address));
        }
#endif
        public void Dispose()
        {
            Request.Dispose();
            Request = null;
            System.GC.SuppressFinalize(this);
        }

        internal static ZipCodeRequest Create() 
            => new ZipCodeRequest();
    }
}
