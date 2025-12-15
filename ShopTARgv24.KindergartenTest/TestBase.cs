using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopTARgv24.ApplicationServices.Services;
using ShopTARgv24.Core.ServiceInterface;
using ShopTARgv24.Data;
using ShopTARgv24.KindergartenTest.Mock;

namespace ShopTARgv24.KindergartenTest
{
    public abstract class TestBase : IDisposable
    {
        protected IServiceProvider ServiceProvider { get; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IKindergartenServices, KindergartenServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockHostEnvironment>();

            services.AddDbContext<ShopTARgv24Context>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                
            });
        }

        protected T Svc<T>() where T : notnull
        {
            return ServiceProvider.GetRequiredService<T>();
        }

        public void Dispose()
        {
        }
    }
}
