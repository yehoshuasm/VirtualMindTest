using System;
using System.ComponentModel.DataAnnotations;

namespace VirtualMindApi.Database.Entities
{
    public class CurrencyPurchaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExecutedOn { get; set; }
    }
}
