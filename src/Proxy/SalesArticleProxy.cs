namespace Linn.LinnappsUi.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.LinnappsUi.Domain.Products;
    using Linn.LinnappsUi.Domain.RemoteServices;
    using Linn.LinnappsUi.Proxy.Exceptions;

    public class SalesArticleProxy : ISalesArticleService
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public SalesArticleProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<SalesArticle> Search(string searchTerm)
        {
            var uri = new Uri($"{this.rootUri}/linnapps-api/sales-articles/search?searchTerm={searchTerm}", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to execute search");
            }

            var json = new JsonSerializer();
            return json.Deserialize<IEnumerable<SalesArticle>>(response.Value);
        }
    }
}
