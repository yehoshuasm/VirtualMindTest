using Microsoft.EntityFrameworkCore;
using VirtualMindApi.Database.Entities;

namespace VirtualMindApi.Database
{
    public class VirtualMindDbContext : DbContext
    {
        public VirtualMindDbContext() { }

        public VirtualMindDbContext(DbContextOptions<VirtualMindDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<CurrencyPurchaseEntity> CurrencyPurchases { get; set; }
    }
}
