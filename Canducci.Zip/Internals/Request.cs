using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Canducci.Zip.MSTest")]
namespace Canducci.Zip.Internals
{
   internal class Request : IDisposable
   {
      public string GetString(Uri url)
      {
         string response = string.Empty;
         WebRequest webRequest = WebRequest.Create(url);
         using (WebResponse webResponse = webRequest.GetResponse())
         {
            using (Stream stream = webResponse.GetResponseStream())
            {
               using (StreamReader reader = new StreamReader(stream))
               {
                  response = reader.ReadToEnd();
               }
            }
         }
         return response;
      }

      public async Task<string> GetStringAsync(Uri url)
      {
         string response = string.Empty;
         WebRequest webRequest = WebRequest.Create(url);
         using (WebResponse webResponse = await webRequest.GetResponseAsync())
         {
            using (Stream stream = webResponse.GetResponseStream())
            {
               using (StreamReader reader = new StreamReader(stream))
               {
                  response = await reader.ReadToEndAsync();
               }
            }
         }
         return response;
      }

      public void Dispose()
      {
         GC.SuppressFinalize(this);
      }
   }
}
