using System;
using System.Threading.Tasks;
namespace Canducci.Zip.Interfaces
{
   public interface IZipCodeLoad : IDisposable
   {
      ZipCodeResult Find(ZipCode value);
      ZipCodeResult Find(string value);
      Task<ZipCodeResult> FindAsync(ZipCode value);
      Task<ZipCodeResult> FindAsync(string value);
   }
}