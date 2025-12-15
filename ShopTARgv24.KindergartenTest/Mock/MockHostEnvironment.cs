using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ShopTARgv24.KindergartenTest.Mock
{
    public class MockHostEnvironment : IHostEnvironment
    {
        public string ApplicationName { get; set; } = "TestApp";
        public string EnvironmentName { get; set; } = "Development";
        public string ContentRootPath { get; set; } = "";
        public IFileProvider ContentRootFileProvider { get; set; } = null!;
    }
}

