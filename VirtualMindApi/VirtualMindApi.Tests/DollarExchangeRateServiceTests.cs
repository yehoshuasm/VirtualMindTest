using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using VirtualMindApi.Providers;
using VirtualMindApi.Services;

namespace VirtualMindApi.Tests
{
    public class DollarExchangeRateServiceTests
    {
        private DollarExchangeRateService dollarExchangeRateService;
        private const decimal testDollarExchangeRate = 95;
        private const string currencyCode = "dolar";

        [SetUp]
        public void Setup()
        {
            var dollarExchangeRateProvider = new Mock<IDollarExchangeRateProvider>();

            dollarExchangeRateProvider.Setup(t => t.GetExchangeRate()).ReturnsAsync(testDollarExchangeRate);

            dollarExchangeRateService = new DollarExchangeRateService(dollarExchangeRateProvider.Object);
        }

        [Test]
        public async Task Test1Async()
        {
            var rate = await dollarExchangeRateService.GetCurrencyExchangeRate();

            Assert.AreEqual(currencyCode, rate.CurrencyCode);
            Assert.AreEqual(testDollarExchangeRate, rate.Rate);
        }
    }
}
