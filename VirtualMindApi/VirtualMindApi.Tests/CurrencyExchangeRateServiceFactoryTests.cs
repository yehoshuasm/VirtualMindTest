using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using VirtualMindApi.Providers;
using VirtualMindApi.Providers.BancoProvincia;
using VirtualMindApi.Services;

namespace VirtualMindApi.Tests
{
    public class CurrencyExchangeRateServiceTests
    {
        private CurrencyExchangeRateServiceFactory currencyExchangeRateServiceFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddScoped<IDollarExchangeRateProvider, BancoProvinciaDollarExchangeRateProvider>();
            services.AddScoped<DollarExchangeRateService>();
            services.AddScoped<RealExchangeRateService>();

            var serviceProvider = services.BuildServiceProvider();

            currencyExchangeRateServiceFactory = new CurrencyExchangeRateServiceFactory(serviceProvider);
        }

        [Test]
        public void Test1()
        {
            var currencyExchangeRateService = currencyExchangeRateServiceFactory.GetCurrencyExchangeRateService("dolar");

            Assert.IsInstanceOf<DollarExchangeRateService>(currencyExchangeRateService);
        }

        [Test]
        public void Test2()
        {
            var currencyExchangeRateService = currencyExchangeRateServiceFactory.GetCurrencyExchangeRateService("real");

            Assert.IsInstanceOf<RealExchangeRateService>(currencyExchangeRateService);
        }
    }
}