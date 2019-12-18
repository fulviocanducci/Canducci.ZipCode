using System;
using System.Text.Json;

namespace Canducci.Zip.Internals
{
   internal class Deserialize : IDisposable
   {
      internal T ConvertTo<T>(string json)
      {
         return JsonSerializer.Deserialize<T>(json);
      }

      public void Dispose()
      {
         System.GC.SuppressFinalize(this);
      }

      internal static Deserialize Create() => new Deserialize();
   }
}
