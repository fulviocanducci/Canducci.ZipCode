namespace Canducci.Zip
{
    public sealed class AddressCodeResult
    {
        public bool IsValid { get; }
        public AddressCodeItem AddressCodeItem { get; }

        internal AddressCodeResult(bool isValid, AddressCodeItem addressCodeItem = null)
        {
            IsValid = isValid;
            AddressCodeItem = addressCodeItem;
        }
    }
}
