using System.Collections.Generic;

namespace Canducci.Zip
{    
    public class AddressCodeItem : List<ZipCodeItem>
    {
        public static implicit operator AddressCodeItem(AddressCodeResult v) => v.Value;        
    }
}
