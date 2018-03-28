using Microsoft.Extensions.DependencyInjection;
namespace Canducci.Zip.Mvc.Core
{
    public static class CanducciZipMvcCoreExtensions
    {
        public static IServiceCollection AddZipCodeAndAdressCodeServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressCodeLoad, AddressCodeLoad>();
            services.AddScoped<IZipCodeLoad, ZipCodeLoad>();
            return services;
        }
    }
}
