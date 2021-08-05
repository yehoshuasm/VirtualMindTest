using System.Threading.Tasks;
using VirtualMindApi.Models;

namespace VirtualMindApi.Services
{
    public interface ICurrencyPurchasingService
    {
        Task<CurrencyPurchasingOperationResult> ExecuteCurrencyPurchase(int userId, CurrencyPurchaseOrder currencyPurchaseOrder);
    }
}
