﻿namespace Canducci.Zip
{
    [Newtonsoft.Json.JsonArray(AllowNullItems = true)]
    public class AddressCodeItem : System.Collections.Generic.List<ZipCodeItem>
    {
        public static implicit operator AddressCodeItem(AddressCodeResult v) 
            => v.Value;        
    }
}
