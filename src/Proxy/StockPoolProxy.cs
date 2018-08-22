namespace Linn.LinnappsUi.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.LinnappsUi.Domain.Logistics;
    using Linn.LinnappsUi.Domain.RemoteServices;
    using Linn.LinnappsUi.Proxy.Exceptions;

    public class StockPoolProxy : IStockPoolService
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public StockPoolProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public StockPool GetStockPool(int id)
        {
            var uri = new Uri($"{this.rootUri}/linnapps-api/stock-pools/{id}", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get stock pool");
            }

            var json = new JsonSerializer();
            return json.Deserialize<StockPool>(response.Value);
        }

        public IEnumerable<StockPool> GetStockPools()
        {
            var uri = new Uri($"{this.rootUri}/linnapps-api/stock-pools", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get stock pools");
            }

            var json = new JsonSerializer();
            return json.Deserialize<IEnumerable<StockPool>>(response.Value);
        }
    }
}
