namespace Canducci.Zip
{
    public static class Extensions
    {
        private static System.Collections.Generic.IDictionary<string, string> dic =
                new System.Collections.Generic.Dictionary<string, string>();

        static Extensions()
        {
            System.Array items = System.Enum.GetValues(typeof(ZipCodeUf));
            System.Collections.IEnumerator list = items.GetEnumerator();
            while (list.MoveNext())
            {
                string item = list.Current.ToString();
                dic.Add(item, item);
            }
        }

        public static System.Collections.Generic.IDictionary<string, string> UFToList(this IAddressCodeLoad load)
        {
            return dic;
        }

        public static System.Collections.Generic.IDictionary<string, string> UFToList(this IZipCodeLoad load)
        {
            return dic;
        }
    }
}
