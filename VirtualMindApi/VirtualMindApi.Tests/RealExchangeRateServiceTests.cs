using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VirtualMindApi.Providers;
using VirtualMindApi.Services;

namespace VirtualMindApi.Tests
{
    public class RealExchangeRateServiceTests
    {
        private RealExchangeRateService realExchangeRateService;
        private const decimal testDollarExchangeRate = 95;
        private const string currencyCode = "real";

        [SetUp]
        public void Setup()
        {
            var dollarExchangeRateProvider = new Mock<IDollarExchangeRateProvider>();

            dollarExchangeRateProvider.Setup(t => t.GetExchangeRate()).ReturnsAsync(testDollarExchangeRate);

            realExchangeRateService = new RealExchangeRateService(dollarExchangeRateProvider.Object);
        }

        [Test]
        public async Task Test1Async()
        {
            var rate = await realExchangeRateService.GetCurrencyExchangeRate();

            Assert.AreEqual(currencyCode, rate.CurrencyCode);
            Assert.AreEqual(testDollarExchangeRate / 4, rate.Rate);
        }
    }
}
