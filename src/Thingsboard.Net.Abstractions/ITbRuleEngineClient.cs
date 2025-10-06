using System.Threading;
using System.Threading.Tasks;

namespace Thingsboard.Net;

/// <summary>
/// Partial definition of the Thingsboard Rule Engine API client. (Only includes methods we use.)
/// Extended by us.
/// </summary>
public interface ITbRuleEngineClient : ITbClient<ITbRuleEngineClient>
{
    Task<string> PushMessageAsEntityAsync(
        TbEntityId entityId,
        string message,
        CancellationToken cancel = default);
}