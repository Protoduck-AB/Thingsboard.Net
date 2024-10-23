using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Thingsboard.Net.Flurl.Utilities;

namespace Thingsboard.Net.Flurl;

public class FlurlTbAuthClient : FlurlTbClient<ITbAuthClient>, ITbAuthClient
{
    private static readonly JsonSerializerSettings JsonSerializerSettingsWithNullableGuidConverter = new()
    {
        Converters = new List<JsonConverter> { new GuidNullableConverter() }
    };
    
    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public FlurlTbAuthClient(IRequestBuilder builder) : base(builder)
    {

    }

    /// <summary>
    /// Retrieves the current user.
    /// </summary>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task<TbUserInfo?> GetCurrentUserAsync(CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<TbUserInfo>()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment("/api/auth/user")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .SendAsync(HttpMethod.Get, cancellationToken: cancel)
                .ReceiveString();
                // .GetJsonAsync<TbUserInfo>(cancel);
            
            return JsonConvert.DeserializeObject<TbUserInfo>(response, JsonSerializerSettingsWithNullableGuidConverter);
        });
    }

    /// <summary>
    /// Change the password for the User which credentials are used to perform this REST API call. Be aware that previously generated JWT tokens will be still valid until they expire.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    public Task ChangePasswordAsync(TbChangePasswordRequest request, CancellationToken cancel = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));


        var policy = RequestBuilder.GetPolicyBuilder()
            .RetryOnHttpTimeout()
            .RetryOnUnauthorized()
            .Build();

        return policy.ExecuteAsync(async builder =>
            await builder.CreateRequest()
                .AppendPathSegment("/api/auth/changePassword")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostJsonAsync(request, cancel));
    }
}
