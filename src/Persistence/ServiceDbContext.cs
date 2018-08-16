namespace Linn.LinnappsUi.Persistence
{
    using Linn.LinnappsUi.Domain.Products;

    using Microsoft.EntityFrameworkCore;

    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<SaCoreType> SaCoreType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SaCoreType>().ToTable("SA_CORE_TYPES");
            builder.Entity<SaCoreType>().HasKey(s => s.CoreType);

            builder.Entity<SaCoreType>().Property(s => s.CoreType).HasColumnName("CORE_TYPE");
            builder.Entity<SaCoreType>().Property(s => s.Description).HasColumnName("DESCRIPTION").HasMaxLength(30);
            builder.Entity<SaCoreType>().Property(s => s.DateInvalid).HasColumnName("DATE_INVALID");
            builder.Entity<SaCoreType>().Property(s => s.InsertType).HasColumnName("INSERT_TYPE").HasMaxLength(20);
            builder.Entity<SaCoreType>().Property(s => s.LookaheadDays).HasColumnName("LOOKAHEAD_DAYS");
            builder.Entity<SaCoreType>().Property(s => s.TriggerLevel).HasColumnName("TRIGGER_LEVEL");
            builder.Entity<SaCoreType>().Property(s => s.SortOrder).HasColumnName("SORT_ORDER");

            base.OnModelCreating(builder);
        }
    }
}
