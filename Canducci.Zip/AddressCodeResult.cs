namespace Canducci.Zip
{
    public sealed class AddressCodeResult
    {
        public bool IsValid { get; }
        public AddressCodeItem Value { get; }

        internal AddressCodeResult()
        {
        }

        internal AddressCodeResult(AddressCodeItem value)
        {
            Value = value;
            IsValid = (value?.Count > 0);
        }

        public static implicit operator bool(AddressCodeResult v)
            => v.IsValid;
    }
}
