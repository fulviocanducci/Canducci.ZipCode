using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Canducci.Zip.WebSiteApiAngular.Models;
using Microsoft.AspNetCore.Http;

namespace Canducci.Zip.WebSiteApiAngular.Controllers
{
    public class ZipCodeAddressController : Controller
    {
        public readonly AddressCodeLoad AddressCodeLoad;
        public readonly ZipCodeLoad ZipCodeLoad;

        public ZipCodeAddressController(AddressCodeLoad addressCodeLoad, ZipCodeLoad zipCodeLoad)
        {
            AddressCodeLoad = addressCodeLoad;
            ZipCodeLoad = zipCodeLoad;
        }

        [Route("zipcode")]
        [HttpPost()]       
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> ZipCodePost([FromBody] ZipCodeNumber zip)
        {            
            if (!String.IsNullOrEmpty(zip.Zip))
            {
                if (ZipCode.TryParse(zip.Zip, out ZipCode zipCode))
                {
                    var result = await ZipCodeLoad.FindAsync(zipCode);
                    if (result)
                    {
                        return Json(result.ZipCodeItem);
                    }
                }
            }
            return Json(new { });
        }
    }
}