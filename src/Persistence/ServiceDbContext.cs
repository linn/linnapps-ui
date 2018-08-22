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

        public DbSet<SalesArticle> SalesArticle { get; set; }

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

            builder.Entity<SalesArticle>().ToTable("SALES_ARTICLES");
            builder.Entity<SalesArticle>().HasKey(s => s.ArticleNumber);

            builder.Entity<SalesArticle>().Property(s => s.ArticleNumber).HasColumnName("ARTICLE_NUMBER").HasMaxLength(14);
            builder.Entity<SalesArticle>().Property(s => s.InvoiceDescription).HasColumnName("INVOICE_DESCRIPTION").HasMaxLength(100);
            builder.Entity<SalesArticle>().Property(s => s.TypeOfSale).HasColumnName("TYPE_OF_SALE").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(s => s.PhaseInDate).HasColumnName("PHASE_IN_DATE");
            builder.Entity<SalesArticle>().Property(s => s.PhaseOutDate).HasColumnName("PHASE_OUT_DATE");
            builder.Entity<SalesArticle>().Property(s => s.EanCode).HasColumnName("EAN_CODE").HasMaxLength(13);
            builder.Entity<SalesArticle>().Property(s => s.PackingDescription).HasColumnName("PACKING_DESCRIPTION").HasMaxLength(50);
            builder.Entity<SalesArticle>().Property(s => s.SaDiscountFamily).HasColumnName("SA_DISCOUNT_FAMILY").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(s => s.CartonType).HasColumnName("CARTON_TYPE").HasMaxLength(10);

            base.OnModelCreating(builder);
        }
    }
}
