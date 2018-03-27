namespace Canducci.Zip
{
    public sealed class ZipCodeResult
    {
        public bool IsValid { get; }
        public ZipCodeItem ZipCodeItem { get; }

        internal ZipCodeResult(bool isValid, ZipCodeItem zipCodeItem = null)
        {
            IsValid = isValid;
            ZipCodeItem = zipCodeItem;
        }        

        public static implicit operator ZipCodeItem(ZipCodeResult zipCodeResult)
            => zipCodeResult.ZipCodeItem;

        public static implicit operator bool(ZipCodeResult zipCodeResult)
            => zipCodeResult.IsValid;
    }
}
