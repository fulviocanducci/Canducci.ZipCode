using Canducci.Zip.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
         return View();
      }
   }
}