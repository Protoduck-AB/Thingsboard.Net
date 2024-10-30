using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Thingsboard.Net.Exceptions;
using Thingsboard.Net.Flurl.Utilities;
using Thingsboard.Net.TbGroupPermissionModels;

namespace Thingsboard.Net.Flurl;

public class FlurlTbGroupPermissionClient : FlurlTbClient<ITbGroupPermissionClient>, ITbGroupPermissionClient
{
    public FlurlTbGroupPermissionClient(IRequestBuilder builder) : base(builder)
    {
    }
    
    public Task<TbGroupPermissionResponse> SaveGroupPermissionAsync(TbGroupPermissionRequest groupPermission, CancellationToken cancel = default)
    {
        if (groupPermission == null) throw new ArgumentNullException(nameof(groupPermission));

        var policy = RequestBuilder.GetPolicyBuilder<TbGroupPermissionResponse>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment("/api/groupPermission")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(groupPermission, cancel)
                .ReceiveJson<TbGroupPermissionResponse>();

            return response;
        });
    }
}