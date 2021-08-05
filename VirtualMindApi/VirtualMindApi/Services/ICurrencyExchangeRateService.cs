using System.Threading.Tasks;

namespace VirtualMindApi.Services
{
    public interface ICurrencyExchangeRateService
    {
        Task<CurrencyExchangeRate> GetCurrencyExchangeRate();
    }
}
