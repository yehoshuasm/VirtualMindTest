using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualMindApi.Database;
using VirtualMindApi.Database.Entities;
using VirtualMindApi.Providers;
using VirtualMindApi.Services;

namespace VirtualMindApi.Tests
{
    public class CurrencyPurchasingServiceTests
    {
        private CurrencyPurrchasingService currencyPurrchasingService;
        private const decimal testDollarExchangeRate = 95;
        private List<CurrencyPurchaseEntity> data = new List<CurrencyPurchaseEntity>
        {
            new CurrencyPurchaseEntity
            {
                Amount = 190,
                CurrencyCode = "dolar",
                ExecutedOn = DateTime.UtcNow,
                Id = 1,
                UserId = 1
            },
            new CurrencyPurchaseEntity
            {
                Amount = 290,
                CurrencyCode = "real",
                ExecutedOn = DateTime.UtcNow,
                Id = 1,
                UserId = 1
            }
        };

        [SetUp]
        public void Setup()
        {
            var set = new Mock<DbSet<CurrencyPurchaseEntity>>();
            var data = this.data.AsQueryable();

            set.As<IQueryable<CurrencyPurchaseEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            set.As<IQueryable<CurrencyPurchaseEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            set.As<IQueryable<CurrencyPurchaseEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            set.As<IQueryable<CurrencyPurchaseEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var dollarExchangeRateProvider = new Mock<IDollarExchangeRateProvider>();
            var currencyExchangeRateServiceFactory = new Mock<ICurrencyExchangeServiceFactory>();

            dollarExchangeRateProvider.Setup(t => t.GetExchangeRate()).ReturnsAsync(testDollarExchangeRate);

            currencyExchangeRateServiceFactory.Setup(t => t.GetCurrencyExchangeRateService("dolar"))
                .Returns(new DollarExchangeRateService(dollarExchangeRateProvider.Object));
            currencyExchangeRateServiceFactory.Setup(t => t.GetCurrencyExchangeRateService("real"))
                .Returns(new RealExchangeRateService(dollarExchangeRateProvider.Object));

            var currenciesService = new CurrenciesService();
            var context = new Mock<VirtualMindDbContext>();

            context.Setup(t => t.CurrencyPurchases).Returns(set.Object);

            currencyPurrchasingService = new CurrencyPurrchasingService(currencyExchangeRateServiceFactory.Object, currenciesService, context.Object);
        }

        [Test]
        public async Task TestValidDollarPurchase()
        {
            var testUserId = 1;
            var currencyPurchaseOrder = new CurrencyPurchaseOrder
            {
                Amount = 95,
                CurrencyCode = "dolar",
            };

            var result = await currencyPurrchasingService.ExecuteCurrencyPurchase(testUserId, currencyPurchaseOrder);

            Assert.AreEqual("Completed", result.Status);
        }

        [Test]
        public async Task TestNotValidDollarPurchase()
        {
            var testUserId = 1;
            var currencyPurchaseOrder = new CurrencyPurchaseOrder
            {
                Amount = 1000,
                CurrencyCode = "dolar",
            };

            var result = await currencyPurrchasingService.ExecuteCurrencyPurchase(testUserId, currencyPurchaseOrder);

            Assert.AreEqual("Rejected", result.Status);
            Assert.AreEqual("Límite excedido.", result.Error);
        }

        [Test]
        public async Task TestValidRealPurchase()
        {
            var testUserId = 1;
            var currencyPurchaseOrder = new CurrencyPurchaseOrder
            {
                Amount = 95,
                CurrencyCode = "real",
            };

            var result = await currencyPurrchasingService.ExecuteCurrencyPurchase(testUserId, currencyPurchaseOrder);

            Assert.AreEqual("Completed", result.Status);
        }

        [Test]
        public async Task TestNotValidRealPurchase()
        {
            var testUserId = 1;
            var currencyPurchaseOrder = new CurrencyPurchaseOrder
            {
                Amount = 285,
                CurrencyCode = "real",
            };

            var result = await currencyPurrchasingService.ExecuteCurrencyPurchase(testUserId, currencyPurchaseOrder);

            Assert.AreEqual("Rejected", result.Status);
            Assert.AreEqual("Límite excedido.", result.Error);
        }

        [Test]
        public async Task TestNotValidCurrencyCode()
        {
            var testUserId = 1;
            var currencyPurchaseOrder = new CurrencyPurchaseOrder
            {
                Amount = 285,
                CurrencyCode = "euro",
            };

            var result = await currencyPurrchasingService.ExecuteCurrencyPurchase(testUserId, currencyPurchaseOrder);

            Assert.AreEqual("Rejected", result.Status);
            Assert.AreEqual("Moneda no válida.", result.Error);
        }
    }
}
