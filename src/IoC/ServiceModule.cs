namespace Linn.LinnappsUi.IoC
{
    using Autofac;

    using Linn.Common.Configuration;
    using Linn.Common.Proxy;
    using Linn.LinnappsUi.Domain.RemoteServices;
    using Linn.LinnappsUi.Domain.Reports;
    using Linn.LinnappsUi.Proxy;
    using Linn.LinnappsUi.Service.Reports;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ThingProxy>().As<IThingService>();
            builder.RegisterType<SaCoreTypesReportService>().As<ISaCoreTypesReportService>();

            // proxies
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<StockPoolProxy>().As<IStockPoolService>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
        }
    }
}