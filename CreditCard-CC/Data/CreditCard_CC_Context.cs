using CreditCard_CC.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCard_CC.Data
{
    public class CreditCard_CC_Context : DbContext
    {
        public DbSet<CreditCard> CreditCards { get; set; }

        public CreditCard_CC_Context() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CreditCardsDb");
        }
    }
}
