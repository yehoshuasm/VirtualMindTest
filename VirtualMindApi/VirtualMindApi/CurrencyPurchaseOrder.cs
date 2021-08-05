using System.ComponentModel.DataAnnotations;

namespace VirtualMindApi
{
    public class CurrencyPurchaseOrder
    {
        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
