namespace Canducci.Zip
{
    public sealed class ZipCodeResult
    {
        public bool IsValid { get; }
        public ZipCodeItem Value { get; }

        internal ZipCodeResult(bool isValid)
            : this(isValid, null)
        {
        }

        internal ZipCodeResult(bool isValid, ZipCodeItem value)
        {
            IsValid = isValid;
            Value = value;
        }        

        public static implicit operator ZipCodeItem(ZipCodeResult zipCodeResult)
            => zipCodeResult.Value;

        public static implicit operator bool(ZipCodeResult zipCodeResult)
            => zipCodeResult.IsValid;
    }
}
