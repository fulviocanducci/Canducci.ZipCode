namespace Canducci.Zip
{
    [Newtonsoft.Json.JsonArray(AllowNullItems = true)]
    public sealed class AddressCodeItem : System.Collections.Generic.List<ZipCodeItem>
    {
        public static implicit operator AddressCodeItem(AddressCodeResult v) 
            => v.AddressCodeItem;        
    }
}
