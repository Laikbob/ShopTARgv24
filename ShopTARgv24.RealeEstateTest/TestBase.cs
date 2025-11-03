using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using ShopTARgv24.Data;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.RealeEstateTest.Macros;
using ShopTARgv24.ApplicationServices.Services;

namespace ShopTARgv24.RealeEstateTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupService(services);
            serviceProvider = services.BuildServiceProvider(); 
        }

        public virtual void SetupService(IServiceCollection services)
        {
            services.AddScoped<IRealEstateServices, RealEstateServices>();

            services.AddDbContext<ShopTARgv24Context>(x =>
            {
                x.UseInMemoryDatabase("TestDb");
                x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(t => macroBaseType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

           
            foreach (var macro in macros)
            {
                services.AddScoped(macroBaseType, macro);
            }
        }

        protected T Svc<T>()
        {
            return serviceProvider.GetRequiredService<T>();
        }

        public void Dispose()
        {
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
