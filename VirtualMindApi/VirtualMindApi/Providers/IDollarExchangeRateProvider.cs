using System.Threading.Tasks;

namespace VirtualMindApi.Providers
{
    public interface IDollarExchangeRateProvider
    {
        Task<decimal> GetExchangeRate();
    }
}
