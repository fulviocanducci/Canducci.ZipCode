using System;
using System.Threading.Tasks;

namespace Canducci.Zip.Interfaces
{
    public interface IAddressCodeLoad: IDisposable
    {
        AddressCodeResult Find(AddressCode value);
        AddressCodeResult Find(ZipCodeUf uf, string city, string address);
        Task<AddressCodeResult> FindAsync(AddressCode value);
        Task<AddressCodeResult> FindAsync(ZipCodeUf uf, string city, string address);
    }
}