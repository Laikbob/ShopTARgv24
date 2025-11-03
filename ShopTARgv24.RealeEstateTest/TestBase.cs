using Microsoft.Extensions.DependencyInjection;

namespace ShopTARgv24.RealeEstateTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider {  get; set; }

        protected TestBase() 
        {
            var services = new ServiceCollection();
            SetupService(services);
            serviceProvider = serviceProvider.BuildServiceProvider();
        }
        public virtual void SetupService(IServiceCollection services)
        {
            services.AddDbContext<ShopTARgv24Context>(x =>
            {
                x.UseInMemoryDatabase("TestDb");
                x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.Tra));
            });
        }
    }

           
}
