namespace Canducci.Zip.ConsoleApp4_0
{
    class Program
    {
        static void Main(string[] args)
        {
            //ZipCodeLoad load = new ZipCodeLoad();
            //ZipCodeResult result = load.Find("19200000");
            //if (result)
            //{
            //    ZipCodeItem zipCodeItem = result;
            //}

            //load.Dispose();

            AddressCodeLoad load = new AddressCodeLoad();
            AddressCodeResult result = load.Find(new AddressCode(ZipCodeUf.SP, "Presidente Prudente", "AVE"));
            load.Dispose();

        }
    }
}
