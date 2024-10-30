using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Thingsboard.Net.Flurl.Utilities;
using Thingsboard.Net.TbEntityGroupModels;

namespace Thingsboard.Net.Flurl;

public class FlurlTbEntityGroupClient : FlurlTbClient<ITbEntityGroupClient>, ITbEntityGroupClient
{
    public FlurlTbEntityGroupClient(IRequestBuilder builder) : base(builder)
    {
    }

    public Task<TbEntityGroup[]> GetEntityGroupsByOwnerAndTypeAsync(TbEntityType ownerType, Guid ownerId, TbEntityType entityType,
        CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbEntityGroup[]>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackValueOn(HttpStatusCode.NotFound, Array.Empty<TbEntityGroup>())
            .Build();
        
        return policy.ExecuteAsync(async builder =>
        {
            // entityType should be entityGroupType which is a subset
            // of all entity types.
            // Valid values are: ASSET, CUSTOMER, DASHBOARD, DEVICE, EDGE, ENTITY_VIEW, USER
            var response = await builder.CreateRequest()
                .AppendPathSegment($"/api/entityGroups/{ownerType}/{ownerId}/{entityType}")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .GetJsonAsync<TbEntityGroup[]>(cancel);
                
            return response;
        });
    }
    
    public Task<TbEntityGroup> CreateEntityGroupAsync(TbEntityGroup entityGroup, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbEntityGroup>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();
        
        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment("/api/entityGroup")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(entityGroup, cancel)
                .ReceiveJson<TbEntityGroup>();
                
            return response;
        });
    }
}