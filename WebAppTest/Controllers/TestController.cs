using Canducci.Zip;
using Canducci.Zip.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
   public class TestController : Controller
   {
      public IZipCodeLoad ZipCodeLoad { get; }
      public IAddressCodeLoad AddressCodeLoad { get; }

      public TestController(IZipCodeLoad zipCodeLoad, IAddressCodeLoad addressCodeLoad)
      {
         ZipCodeLoad = zipCodeLoad;
         AddressCodeLoad = addressCodeLoad;
      }

      public IActionResult Index()
      {
         ViewBag.Ufs = ZipCodeLoad.UFToList();
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Index([FromBody] ZipCodeData data)
      {
         if (ModelState.IsValid)
         {
            if (ZipCode.TryParse(data.Value, out ZipCode zipCode))
            {
               ZipCodeResult zipCodeResult = await ZipCodeLoad.FindAsync(zipCode);
               return Json(zipCodeResult);
            }
         }
         return Json(new { IsValid = false });
      }

      [HttpPost]
      public async Task<IActionResult> Address([FromBody] AddressCodeData data)
      {
         if (AddressCode.TryParse(ParseZipCodeUf(data.Uf), data.City, data.Address, out AddressCode addressCode))
         {
            AddressCodeResult addressCodeResult = await AddressCodeLoad.FindAsync(addressCode);
            return Json(addressCodeResult);
         }
         return Json(new { IsValid = false });
      }

      private ZipCodeUf ParseZipCodeUf(string uf) => Enum.Parse<ZipCodeUf>(uf);
   }
}