using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace intro1.UnitTests
{
    public class TestWebHosting : IWebHostEnvironment
    {
        public string ApplicationName { get; set; }
        public IFileProvider ContentRootFileProvider { get; set; }
        public string ContentRootPath { get; set; }
        public string EnvironmentName { get; set; }
        public IFileProvider WebRootFileProvider { get; set; }
        public string WebRootPath { get; set; }
    }
}