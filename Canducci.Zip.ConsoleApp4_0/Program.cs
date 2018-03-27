using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Canducci.Zip.ConsoleApp4_0
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipCodeLoad load = new ZipCodeLoad();
            ZipCodeResult result = load.Find("19200000");
            if (result)
            {
                ZipCodeItem zipCodeItem = (ZipCodeItem)result;
            }

            load.Dispose();
        }
    }
}
