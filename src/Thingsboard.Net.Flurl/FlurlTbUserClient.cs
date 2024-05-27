using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Thingsboard.Net.Exceptions;
using Thingsboard.Net.Flurl.Utilities;

namespace Thingsboard.Net.Flurl;

public class FlurlTbUserClient : FlurlTbClient<ITbUserClient>, ITbUserClient
{
    public FlurlTbUserClient(IRequestBuilder builder) : base(builder)
    {
    }

    public Task<TbExtendedUserInfo?> GetExtendedUserInfo(Guid userId, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbExtendedUserInfo?>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackValueOn(HttpStatusCode.NotFound, null)
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"api/user/info/{userId}")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .GetJsonAsync<TbExtendedUserInfo>(cancel);
            
            return response;
        });
    }

    public Task<TbExtendedUserInfo> SaveUser(bool sendActivationMail, string entityGroupId, string entityGroupIds, TbExtendedUserInfo request,
        CancellationToken cancel = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var policy = RequestBuilder.GetPolicyBuilder<TbExtendedUserInfo>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackOn(HttpStatusCode.NotFound, () => throw new TbEntityNotFoundException(request.Id))
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment("api/user")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .SetQueryParam("sendActivationMail", sendActivationMail)
                .SetQueryParam("entityGroupId", entityGroupId)
                .SetQueryParam("entityGroupIds", entityGroupIds)
                .PostJsonAsync(request, cancel)
                .ReceiveJson<TbExtendedUserInfo>();

            return response;
        });
    }

    public Task<string> GetActivationLink(Guid userId, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<string>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackOn(HttpStatusCode.NotFound, () => throw new TbEntityNotFoundException(new TbEntityId(TbEntityType.USER, userId)))
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"api/user/{userId}/activationLink")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .GetStringAsync(cancel);

            return response;
        });
    }

    public Task DeleteUser(Guid userId, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            await builder.CreateRequest()
                .AppendPathSegment($"api/user/{userId}")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .DeleteAsync(cancel);
        });
    }
    
    public Task<TbPage<TbExtendedUserInfo>> GetCustomerUserInfos(Guid customerId,
        int pageSize,
        int page,
        bool? includeCustomers = null,
        string? textSearch = null,
        TbUserSearchSortProperty? sortProperty = null,
        TbSortOrder? sortOrder = null,
        CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbPage<TbExtendedUserInfo>>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .FallbackValueOn(HttpStatusCode.NotFound, new TbPage<TbExtendedUserInfo>(0,0, false, Array.Empty<TbExtendedUserInfo>()))
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"api/customer/{customerId}/userInfos")
                .SetQueryParam("pageSize", pageSize)
                .SetQueryParam("page", page)
                .SetQueryParam("includeCustomers", includeCustomers)
                .SetQueryParam("textSearch", textSearch)
                .SetQueryParam("sortProperty", sortProperty)
                .SetQueryParam("sortOrder", sortOrder)
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .GetJsonAsync<TbPage<TbExtendedUserInfo>>(cancel);

            return response;
        });
    }

    public Task ActivateUser(string activateToken, string password, bool sendActivationMail = false, CancellationToken cancel = default)
    {
        if (string.IsNullOrWhiteSpace(activateToken)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(activateToken));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(password));

        var policy = RequestBuilder.GetPolicyBuilder()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            await builder.CreateRequest()
                .AppendPathSegment("api/noauth/activate")
                .SetQueryParam("sendActivationMail", sendActivationMail)
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(new { activateToken, password }, cancel);
        });
    }
}