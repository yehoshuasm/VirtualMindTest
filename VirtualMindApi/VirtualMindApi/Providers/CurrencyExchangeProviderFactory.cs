using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualMindApi.Providers
{
    public class CurrencyExchangeProviderFactory : ICurrencyExchangeProviderFactory
    {
        public Task GetCurrencyRate(string currencyCode = "")
        {
            throw new NotImplementedException();
        }
    }
}
