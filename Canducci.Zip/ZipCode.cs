namespace Canducci.Zip
{
    public sealed class ZipCode
    {
        #region public_property
        public string Zip { get; private set; }
        #endregion

        #region internal
        internal ZipCode() { }
        internal void SetZip(string zip)
        {
            Zip = zip;
        }
        internal static bool Valid(ref string zip)
        {
            if (zip.Length == 8 || zip.Length == 9 || zip.Length == 10)
            {
                zip = zip.Replace(".", "").Replace("-", "");
                System.Text.RegularExpressions.Regex RegexZip = 
                    new System.Text.RegularExpressions.Regex(@"^\d{8}$");
                if (RegexZip.IsMatch(zip))
                {
                    RegexZip = null;
                    return true;
                }
                RegexZip = null;
            }
            return false;
        }
        #endregion

        #region construct
        public ZipCode(string zip)
        {
            if (!Valid(ref zip))
            {
                throw new ZipCodeException("Zip Code Invalid", new System.FormatException());
            }
            Zip = zip;
        }
        #endregion  

        #region public_static
        public static ZipCode Parse(string zip)
        {
            return new ZipCode(zip);
        }
        
        public static bool TryParse(string zip, out ZipCode zipCode)
        {            
            if (Valid(ref zip))
            {
                zipCode = new ZipCode();
                zipCode.SetZip(zip);
                return true;
            }
            zipCode = null;
            return false;
        }
        #endregion      

        #region operator_implict_zipcode_and_string
        public static implicit operator string(ZipCode value)
            => value.Zip;

        public static implicit operator ZipCode(string value) 
            => Parse(value);
        #endregion
    }
}
