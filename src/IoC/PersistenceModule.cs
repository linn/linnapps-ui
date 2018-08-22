namespace Linn.LinnappsUi.IoC
{
    using Autofac;

    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SalesArticleRepository>().As<ISalesArticleRepository>();
        }
    }
}