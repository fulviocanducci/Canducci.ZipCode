namespace Canducci.Zip
{
    public interface IAddressCodeLoad: System.IDisposable
    {
#if NET40
        AddressCodeResult Find(AddressCode value);
        AddressCodeResult Find(ZipCodeUf uf, string city, string address);
#else
        System.Threading.Tasks.Task<AddressCodeResult> FindAsync(AddressCode value);
        System.Threading.Tasks.Task<AddressCodeResult> FindAsync(ZipCodeUf uf, string city, string address);
#endif
    }
}