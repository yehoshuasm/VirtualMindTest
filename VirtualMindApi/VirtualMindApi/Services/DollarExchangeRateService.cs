using System.Threading.Tasks;
using VirtualMindApi.Enums;
using VirtualMindApi.Providers;

namespace VirtualMindApi.Services
{
    public class DollarExchangeRateService : ICurrencyExchangeRateService
    {
        private readonly IDollarExchangeRateProvider dollarExchangeRateProvider;

        public DollarExchangeRateService(IDollarExchangeRateProvider dollarExchangeRateProvider)
        {
            this.dollarExchangeRateProvider = dollarExchangeRateProvider;
        }

        public async Task<CurrencyExchangeRate> GetCurrencyExchangeRate()
        {
            var dollarExchangeRate = await dollarExchangeRateProvider.GetExchangeRate();

            return new CurrencyExchangeRate()
            {
                CurrencyCode = CurrencyCode.DOLLAR,
                Rate = dollarExchangeRate
            };
        }
    }
}
