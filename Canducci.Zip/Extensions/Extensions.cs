using Canducci.Zip.Interfaces;
using System.Collections.Generic;

namespace Canducci.Zip
{
   public static class Extensions
   {
      private static readonly IDictionary<string, string> dic = new Dictionary<string, string>();

      static Extensions()
      {
         System.Array items = System.Enum.GetValues(typeof(ZipCodeUf));
         System.Collections.IEnumerator list = items.GetEnumerator();
         while (list.MoveNext())
         {
            string item = list.Current.ToString();
            dic.Add(item, item);
         }
      }

      public static IDictionary<string, string> UFToList(this IAddressCodeLoad load)
      {
         if (load is null)
         {
            throw new System.ArgumentNullException(nameof(load));
         }

         return dic;
      }

      public static IDictionary<string, string> UFToList(this IZipCodeLoad load)
      {
         if (load is null)
         {
            throw new System.ArgumentNullException(nameof(load));
         }

         return dic;
      }
   }
}
