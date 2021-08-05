using System.Threading.Tasks;
using VirtualMindApi.Enums;
using VirtualMindApi.Providers;

namespace VirtualMindApi.Services
{
    public class RealExchangeRateService : ICurrencyExchangeRateService
    {
        private readonly IDollarExchangeRateProvider dollarExchangeRateProvider;

        public RealExchangeRateService(IDollarExchangeRateProvider dollarExchangeRateProvider)
        {
            this.dollarExchangeRateProvider = dollarExchangeRateProvider;
        }

        public async Task<CurrencyExchangeRate> GetCurrencyExchangeRate()
        {
            var dollarExchangeRate = await dollarExchangeRateProvider.GetExchangeRate();

            return new CurrencyExchangeRate()
            {
                CurrencyCode = CurrencyCode.REAL,
                Rate = dollarExchangeRate / 4
            };
        }
    }
}
