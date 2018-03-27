namespace Canducci.Zip
{
    public sealed class AddressCodeResult
    {
        public bool IsValid { get; }
        public AddressCodeItem AddressCodeItem { get; }

        internal AddressCodeResult()
        {
        }

        internal AddressCodeResult(AddressCodeItem addressCodeItem)
        {
            AddressCodeItem = addressCodeItem;
            IsValid = (addressCodeItem?.Count > 0);
        }

        public static implicit operator bool(AddressCodeResult v)
            => v.IsValid && v?.AddressCodeItem?.Count > 0;
    }
}
