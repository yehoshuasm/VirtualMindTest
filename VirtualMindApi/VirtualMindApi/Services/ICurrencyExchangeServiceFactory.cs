namespace VirtualMindApi.Services
{
    public interface ICurrencyExchangeServiceFactory
    {
        ICurrencyExchangeRateService GetCurrencyExchangeRateService(string currencyCode);
    }
}
