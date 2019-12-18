using System;

namespace Canducci.Zip.Exceptions
{
   public sealed class AddressCodeException : Exception
   {
      public AddressCodeException()
         :base("UF length is 2 letters and City and Address length more than 2 letters")
      {
      }
   }
}
