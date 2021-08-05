using System.Threading.Tasks;

namespace VirtualMindApi.Providers
{
    interface ICurrencyExchangeProviderFactory
    {
        Task GetCurrencyRate(string currencyCode = "");
    }
}
