using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Thingsboard.Net.Flurl.Utilities;

namespace Thingsboard.Net.Flurl;

public class FlurlTbRuleEngineClient : FlurlTbClient<ITbRuleEngineClient>, ITbRuleEngineClient
{
    public FlurlTbRuleEngineClient(IRequestBuilder builder) : base(builder)
    {
    }

    public Task<string> PushMessageAsEntityAsync(TbEntityId entityId, string message, CancellationToken cancel = default)
    {
        var policy = RequestBuilder.GetPolicyBuilder<string>()
            .RetryOnUnauthorized()
            .RetryOnHttpTimeout()
            .Build();

        return policy.ExecuteAsync(async builder =>
        {
            var response = await builder.CreateRequest()
                .AppendPathSegment($"/api/rule-engine/{entityId.EntityType.ToString()}/{entityId.Id.ToString()}")
                .WithOAuthBearerToken(await builder.GetAccessTokenAsync())
                .PostStringAsync(message, cancel)
                .ReceiveString();

            return response;
        });
    }
}