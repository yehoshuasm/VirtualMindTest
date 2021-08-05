using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualMindApi.Database;
using VirtualMindApi.Database.Entities;
using VirtualMindApi.Models;

namespace VirtualMindApi.Services
{
    public class CurrencyPurrchasingService : ICurrencyPurchasingService
    {
        private ICurrencyExchangeServiceFactory currencyExchangeServiceFactory;
        private ICurrenciesService currenciesService;
        private readonly VirtualMindDbContext context;

        public CurrencyPurrchasingService(ICurrencyExchangeServiceFactory currencyExchangeServiceFactory,
            ICurrenciesService currenciesService, VirtualMindDbContext context)
        {
            this.currencyExchangeServiceFactory = currencyExchangeServiceFactory;
            this.currenciesService = currenciesService;
            this.context = context;
        }

        public async Task<CurrencyPurchasingOperationResult> ExecuteCurrencyPurchase(int userId, CurrencyPurchaseOrder currencyPurchaseOrder)
        {
            var currencyExchangeRateService = currencyExchangeServiceFactory.GetCurrencyExchangeRateService(currencyPurchaseOrder.CurrencyCode);

            if(currencyExchangeRateService == null)
            {
                return new CurrencyPurchasingOperationResult
                {
                    Status = "Rejected",
                    Error = "Moneda no válida."
                };
            }

            var currencyRate = await currencyExchangeRateService.GetCurrencyExchangeRate();
            var currencyAmount = currencyPurchaseOrder.Amount / currencyRate.Rate;

            if (!IsValidCurrencyPurchaseOrderAsync(userId, currencyPurchaseOrder.CurrencyCode, currencyAmount))
            {
                return new CurrencyPurchasingOperationResult
                {
                    Status = "Rejected",
                    Error = "Límite excedido."
                };
            }

            await context.AddAsync(new CurrencyPurchaseEntity
            {
                Amount = currencyAmount,
                CurrencyCode = currencyPurchaseOrder.CurrencyCode,
                UserId = userId,
                ExecutedOn = DateTime.UtcNow
            });

            await context.SaveChangesAsync();

            return new CurrencyPurchasingOperationResult
            {
                Status = "Completed"
            };
        }

        private bool IsValidCurrencyPurchaseOrderAsync(int userId, string currencyCode, decimal currencyAmount)
        {
            var maxCurrencyAmount = currenciesService.GetMaxAmount(currencyCode);

            var monthCurrencyPurchasesAmount = context.CurrencyPurchases
                .Where(t => t.UserId == userId && t.CurrencyCode == currencyCode && t.ExecutedOn.Year == DateTime.UtcNow.Year && t.ExecutedOn.Month == DateTime.UtcNow.Month)
                .Sum(t => t.Amount);

            return (monthCurrencyPurchasesAmount + currencyAmount) <= maxCurrencyAmount;
        }
    }
}
