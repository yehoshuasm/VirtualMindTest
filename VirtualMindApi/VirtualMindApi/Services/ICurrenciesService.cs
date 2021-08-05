using VirtualMindApi.Enums;

namespace VirtualMindApi.Services
{
    public interface ICurrenciesService
    {
        decimal GetMaxAmount(string currencyCode);
    }
}
