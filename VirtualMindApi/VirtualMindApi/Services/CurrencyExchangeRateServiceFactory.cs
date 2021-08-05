using System;
using Microsoft.Extensions.DependencyInjection;
using VirtualMindApi.Enums;

namespace VirtualMindApi.Services
{
    public class CurrencyExchangeRateServiceFactory : ICurrencyExchangeServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CurrencyExchangeRateServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICurrencyExchangeRateService GetCurrencyExchangeRateService(string currencyCode)
        {
            return (currencyCode.ToLower()) switch
            {
                CurrencyCode.DOLLAR => _serviceProvider.GetService<DollarExchangeRateService>(),
                CurrencyCode.REAL => _serviceProvider.GetService<RealExchangeRateService>(),
                _ => null,
            };
        }
    }
}
