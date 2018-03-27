namespace Canducci.Zip
{
    public sealed class ZipCodeResult
    {
        internal ZipCodeResult(bool isValid, ZipCodeItem zipCodeItem = null)
        {
            IsValid = isValid;
            ZipCodeItem = zipCodeItem;
        }
        public bool IsValid { get; }
        public ZipCodeItem ZipCodeItem { get; }

        public static explicit operator ZipCodeItem(ZipCodeResult zipCodeResult)
            => zipCodeResult.ZipCodeItem;

        public static implicit operator bool(ZipCodeResult zipCodeResult)
            => zipCodeResult.IsValid;
    }
}
