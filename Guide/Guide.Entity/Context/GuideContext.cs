using Guide.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Guide.Entity.Context
{
    public partial class GuideContext : DbContext
    {

        public GuideContext(DbContextOptions<GuideContext> options)
            : base(options)
        {
        }
        public DbSet<FinanceEntity> finances { get; set; }
        public DbSet<CurrentTradingPeriodEntity> currentTradingPeriodEntities { get; set; }
        public DbSet<QuoteIndicatorEntity> quoteIndicatorEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinanceEntity>()
             .HasKey(x => x.Id);
        
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

