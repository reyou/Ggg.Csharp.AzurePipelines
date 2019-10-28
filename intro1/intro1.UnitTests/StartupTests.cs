using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace intro1.UnitTests
{
    [TestClass()]
    public class StartupTests
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public StartupTests()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
        }
        [TestMethod()]
        public void StartupTest()
        {
            Startup instance = GetInstance();
            Assert.IsNotNull(instance);
        }

        [TestMethod()]
        public void ConfigureServicesTest()
        {
            Startup instance = GetInstance();
            IServiceCollection services = new ServiceCollection();
            instance.ConfigureServices(services);
        }

        [TestMethod()]
        public void ConfigureTest()
        {
            Startup instance = GetInstance();
            IServiceProvider factoryServices = _factory.Services;
            TestServer factoryServer = _factory.Server;
            IApplicationBuilder app = new ApplicationBuilder(factoryServices, factoryServer);
            IWebHostEnvironment env = new TestWebHosting();
            instance.Configure(app, env);
        }

        private Startup GetInstance()
        {
            IList<IConfigurationProvider> providers = new List<IConfigurationProvider>();
            IConfiguration configuration = new ConfigurationRoot(providers);
            Startup startup = new Startup(configuration);
            return startup;
        }
    }
}