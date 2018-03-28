namespace Canducci.Zip.ConsoleApp4_0
{
    class Program
    {
        static void Main(string[] args)
        {           
            
            IZipCodeLoad zipCodeLoad = new ZipCodeLoad();
            ZipCodeResult result0 = zipCodeLoad.Find("19200000");
            if (result0)
            {
                ZipCodeItem zipCodeItem = result0; //ou zipCodeItem zipCodeItem = result0.Value

            }

            IAddressCodeLoad addressCodeLoad = new AddressCodeLoad();
            AddressCode addressCode = AddressCode.Parse(ZipCodeUf.SP, "Presidente Prudente", "AVE");
            AddressCodeResult result1 = addressCodeLoad.Find(addressCode);
            if (result1)
            {
                AddressCodeItem items = result1;
            }

            System.Collections.Generic.IDictionary<string, string> items_List = zipCodeLoad.UFToList();
            System.Collections.Generic.IDictionary<string, string> items0_List = addressCodeLoad.UFToList();

            zipCodeLoad.Dispose();
            addressCodeLoad.Dispose();

        }
    }
}
