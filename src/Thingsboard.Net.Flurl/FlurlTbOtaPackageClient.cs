using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Thingsboard.Net.Flurl.Utilities;

namespace Thingsboard.Net.Flurl;

public class FlurlTbOtaPackageClient : FlurlTbClient<ITbOtaPackageClient>, ITbOtaPackageClient
{
    public FlurlTbOtaPackageClient(IRequestBuilder builder) : base(builder)
    {
    }

    public Task<TbPage<TbOtaPackage>> GetOtaPackagesAsync(Guid deviceProfileId,  string type, int pageSize, int page, string? textSearch = null,
        TbDeviceSearchSortProperty? sortProperty = null, TbSortOrder? sortOrder = null, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbPage<TbOtaPackage>>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackValueOn(HttpStatusCode.NotFound, TbPage<TbOtaPackage>.Empty)
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"api/otaPackages/{deviceProfileId}/{type}")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .SetQueryParam("pageSize",        pageSize)
                .SetQueryParam("page",            page)
                .SetQueryParam("textSearch",      textSearch)
                .SetQueryParam("sortProperty",    sortProperty)
                .SetQueryParam("sortOrder",       sortOrder)
                .GetJsonAsync<TbPage<TbOtaPackage>>(cancel);

            return response;
        });
    }

    public Task<TbOtaPackage?> GetOtaPackageInfoByIdAsync(Guid otaPackageId, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbOtaPackage?>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackValueOn(HttpStatusCode.NotFound, null)
            .Build();
        
        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"api/otaPackage/info/{otaPackageId}")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .GetJsonAsync<TbOtaPackage>(cancel);

            return response;
        });
    }
}