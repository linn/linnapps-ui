namespace Linn.LinnappsUi.Messaging.Host
{
    using Autofac;

    using Linn.Common.Messaging.RabbitMQ.Autofac;
    using Linn.LinnappsUi.IoC;

    public static class Configuration
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AmazonCredentialsModule>();
            builder.RegisterModule<AmazonSqsModule>();
            builder.RegisterModule<LoggingModule>();
            // builder.RegisterModule<PersistenceModule>();
            // builder.RegisterModule<ServiceModule>();
            // builder.RegisterReceiver("linnapps-ui.q", "linnapps-ui.dlx");

            builder.RegisterType<Listener>().AsSelf();

            return builder.Build();
        }
    }
}
