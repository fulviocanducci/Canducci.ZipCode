using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Canducci.Zip.WebSiteApiAngular.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Canducci.Zip.WebSiteApiAngular.Controllers
{
    public class ZipCodeAddressController : Controller
    {
        public readonly IAddressCodeLoad AddressCodeLoad;
        public readonly IZipCodeLoad ZipCodeLoad;

        public ZipCodeAddressController(IAddressCodeLoad addressCodeLoad, IZipCodeLoad zipCodeLoad)
        {
            AddressCodeLoad = addressCodeLoad;
            ZipCodeLoad = zipCodeLoad;
        }

        [Route("zipcode")]
        [HttpPost()]       
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> ZipCodePost([FromBody] Dictionary<string, string> values)
        {
            var zip = values["zip"];
            if (!String.IsNullOrEmpty(zip))
            {
                if (ZipCode.TryParse(zip, out ZipCode zipCode))
                {
                    var result = await ZipCodeLoad.FindAsync(zipCode);
                    if (result)
                    {
                        return Json(result.Value);
                    }
                }
            }
            return Json(new { });
        }


        [Route("addresscode")]
        [HttpPost()]
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> AddressCodePost([FromBody] Dictionary<string, string> values)
        {
            var uf = values["uf"];
            var city = values["city"];
            var address = values["address"];
            if (AddressCode.TryParse(Enum.Parse<ZipCodeUf>(uf), city, address, out AddressCode addressCode))
            {
                AddressCodeResult addressCodeResult = await AddressCodeLoad.FindAsync(addressCode);
                if (addressCodeResult)
                {
                    return Json(addressCodeResult.Value);
                }
            }            
            return Json(await Task.FromResult<object>(null));
        }


        [Route("uftolist")]
        [HttpPost()]
        [ResponseCache(Duration = 3600)]
        public IActionResult UfToList()
        {
            return Json(AddressCodeLoad
                .UFToList()
                .Select(x => new
                {
                    Name = x.Key,
                    x.Value
                })
            .ToList());
        }
    }
}