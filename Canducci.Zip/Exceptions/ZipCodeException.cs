using System;

namespace Canducci.Zip.Exceptions
{
   public class ZipCodeException : Exception
   {
      public ZipCodeException()
         :base("Zip Code Format Invalid", new FormatException())
      {
      }
   }
}
