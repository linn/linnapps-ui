namespace Linn.LinnappsUi.IoC
{
    using Autofac;

    using Linn.Common.Configuration;
    using Linn.Common.Proxy;
    using Linn.LinnappsUi.Domain.DatabasePackages;
    using Linn.LinnappsUi.Domain.RemoteServices;
    using Linn.LinnappsUi.Domain.Reports;
    using Linn.LinnappsUi.Domain.Reports.Helpers;
    using Linn.LinnappsUi.Proxy;
    using Linn.LinnappsUi.Proxy.DatabasePackages;
    using Linn.LinnappsUi.Service.Reports;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ThingProxy>().As<IThingService>();
            builder.RegisterType<SaCoreTypesReportService>().As<ISaCoreTypesReportService>();
            builder.RegisterType<EanCodeReportService>().As<IEanCodeReportService>();
            builder.RegisterType<CsvCreator>().As<ICsvCreator>();

            // oracle package, procedure, function proxies
            builder.RegisterType<SalaPackProxy>().As<ISalaPack>();

            // rest client proxies
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<StockPoolProxy>().As<IStockPoolService>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
        }
    }
}