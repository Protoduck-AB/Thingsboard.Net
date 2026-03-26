using System;
using System.Collections.Generic;
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
            // Strip the Id field for creation — TB 3.9+ treats a non-null Id as an update
            var body = new
            {
                entityGroup.Name,
                entityGroup.Type,
                ownerId = entityGroup.OwnerId,
                additionalInfo = entityGroup.AdditionalInfo.Count > 0 ? entityGroup.AdditionalInfo : null,
                configuration = entityGroup.Configuration,
            };

            var response = await builder.CreateRequest()
                .AppendPathSegment("/api/entityGroup")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(body, cancel)
                .ReceiveJson<TbEntityGroup>();

            return response;
        });
    }

    public Task AddUsersToEntityGroupAsync(Guid entityGroupId, List<Guid> userIds, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbEntityGroup>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();
        
        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"/api/entityGroup/{entityGroupId}/addEntities")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(userIds, cancel)
                .ReceiveJson<TbEntityGroup>();
                
            return response;
        });
    }

    public Task DeleteUsersFromEntityGroupAsync(Guid entityGroupId, List<Guid> userIds, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbEntityGroup>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();
        
        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"/api/entityGroup/{entityGroupId}/deleteEntities")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(userIds, cancel)
                .ReceiveJson<TbEntityGroup>();
                
            return response;
        });
    }
    

}