using System.Threading;
using System.Threading.Tasks;
using Thingsboard.Net.TbGroupPermissionModels;

namespace Thingsboard.Net;

/// <summary>
/// The base interface for all Thingsboard client.
/// </summary>
/// <typeparam name="TClient"></typeparam>
/// public interface ITbAssetClient : ITbClient<ITbAssetClient>

public interface ITbGroupPermissionClient : ITbClient<ITbGroupPermissionClient>
{
    /// <summary>
    /// Creates a group permission. 
    /// </summary>
    /// <param name="groupPermission">
    /// The group permission to create.
    /// </param>
    /// <param name="cancel">
    /// The cancellation token.
    /// </param>
    /// <returns></returns>
    Task<TbGroupPermissionResponse> SaveGroupPermissionAsync(TbGroupPermissionRequest groupPermission, CancellationToken cancel = default);
}
