namespace Linn.LinnappsUi.IoC
{
    using Autofac;

    using Linn.Common.Persistence;
    using Linn.LinnappsUi.Domain.Repositories;
    using Linn.LinnappsUi.Persistence;
    using Linn.LinnappsUi.Persistence.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionManager>().As<ITransactionManager>();

            builder.RegisterType<SalesArticleRepository>().As<ISalesArticleRepository>();
        }
    }
}