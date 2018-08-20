namespace Linn.LinnappsUi.IoC
{
    using Autofac;

    using Linn.LinnappsUi.Domain.RemoteServices;
    using Linn.LinnappsUi.Proxy;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ThingProxy>().As<IThingService>();
        }
    }
}