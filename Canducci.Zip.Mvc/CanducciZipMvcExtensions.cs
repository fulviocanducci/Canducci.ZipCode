using Canducci.Zip.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace Canducci.Zip.Mvc
{
   public static class CanducciZipMvcExtensions
   {
      public static IServiceCollection AddZipCode(this IServiceCollection service)
      {
         return service.AddScoped<IZipCodeLoad, ZipCodeLoad>();
      }

      public static IServiceCollection AddAddressCode(this IServiceCollection service)
      {
         return service.AddScoped<IAddressCodeLoad, AddressCodeLoad>();
      }

      public static IServiceCollection AddZipCodeAndAddressCode(this IServiceCollection service)
      {
         return service
            .AddZipCode()
            .AddAddressCode();
      }
   }
}
