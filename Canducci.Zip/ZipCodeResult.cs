namespace Canducci.Zip
{
   public sealed class ZipCodeResult
   {
      public bool IsValid { get; }
      public ZipCodeItem Value { get; }

      internal ZipCodeResult(ZipCodeItem value)
      {
         IsValid = !string.IsNullOrEmpty(value.Zip);
         Value = value;
      }

      public static implicit operator bool(ZipCodeResult v) => v.IsValid;
   }
}
