using System;
using System.Text.RegularExpressions;

namespace Canducci.Zip
{
    public sealed class ZipCode
    {
        #region property
        public string Zip { get; private set; }
        #endregion

        #region internal_construct_setZip
        internal ZipCode() { }
        internal void SetZip(string zip)
        {
            Zip = zip;
        }
        #endregion

        #region construct
        public ZipCode(string zip)
        {
            if (!Valid(ref zip))
            {
                throw new ZipCodeException("Zip Code Invalid", new FormatException());
            }
            Zip = zip;
        }
        #endregion  

        #region Parse
        public static ZipCode Parse(string zip)
        {
            return new ZipCode(zip);
        }
        #endregion

        #region TryParse
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

        #region valid
        internal static bool Valid(ref string zip)
        {
            if (zip.Length == 8 || zip.Length == 9 || zip.Length == 10)
            {
                zip = zip.Replace(".", "").Replace("-", "");
                Regex RegexZip = new Regex(@"^\d{8}$");
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
    }
}
