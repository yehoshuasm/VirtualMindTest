using VirtualMindApi.Enums;

namespace VirtualMindApi.Services
{
    public class CurrenciesService : ICurrenciesService
    {
        public decimal GetMaxAmount(string currencyCode)
        {
            switch(currencyCode.ToLower())
            {
                case CurrencyCode.DOLLAR:
                    return 200;
                case CurrencyCode.REAL:
                    return 300;
            }

            return 0;
        }
    }
}
