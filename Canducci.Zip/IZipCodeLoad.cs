namespace Canducci.Zip
{
    public interface IZipCodeLoad: System.IDisposable
    {
#if NET40
        ZipCodeResult Find(ZipCode value);
#else
        System.Threading.Tasks.Task<ZipCodeResult> FindAsync(ZipCode value);
#endif
    }
}