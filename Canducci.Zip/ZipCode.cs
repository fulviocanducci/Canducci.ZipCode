using Canducci.Zip.Exceptions;
using System.Text.RegularExpressions;

namespace Canducci.Zip
{
   public sealed class ZipCode
   {
      public string Value { get; private set; }

      internal ZipCode(string value) 
      {
         Value = value;
      }

      internal static Regex RegexZip = new Regex(@"^\d{8}$");
      internal static bool Valid(ref string value)
      {
         if (value.Length == 8 || value.Length == 9 || value.Length == 10)
         {
            value = value.Replace(".", "").Replace("-", "");            
            return RegexZip.IsMatch(value);
         }
         return false;
      }

      public static ZipCode Parse(string value)
      {
         if (Valid(ref value))
         {
            return new ZipCode(value);
         }
         throw new ZipCodeException();
      }

      public static bool TryParse(string value, out ZipCode zipCode)
      {
         if (Valid(ref value))
         {
            zipCode = new ZipCode(value);
            return true;
         }
         zipCode = null;
         return false;
      }

      public static implicit operator string(ZipCode zipCode) => zipCode.Value;

      public static implicit operator ZipCode(string value) => Parse(value);

   }
}
