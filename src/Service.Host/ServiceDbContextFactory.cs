namespace Linn.LinnappsUi.Service.Host
{
    using Linn.LinnappsUi.Persistence;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class ServiceDbContextFactory : IDesignTimeDbContextFactory<ServiceDbContext>
    {
        public ServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceDbContext>();
            optionsBuilder.UseSqlServer("pretend to use sql server at design time just for scaffolding");
            return new ServiceDbContext(optionsBuilder.Options);
        }
    }
}
