using System;

namespace Canducci.Zip.Internals
{
   internal class Deserialize : IDisposable
   {
      internal T ConvertTo<T>(string json)
      {
         return System.Text.Json.JsonSerializer.Deserialize<T>(json);
      }

      public void Dispose()
      {
         System.GC.SuppressFinalize(this);
      }

      internal static Deserialize Create() => new Deserialize();
   }
}
