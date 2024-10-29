using System;
using System.Threading;
using System.Threading.Tasks;
using Thingsboard.Net.TbEntityGroupModels;

namespace Thingsboard.Net;

public interface ITbEntityGroupClient : ITbClient<ITbEntityGroupClient>
{
    Task<TbEntityGroup[]> GetEntityGroupsByOwnerAndTypeAsync(TbEntityType ownerType, Guid ownerId, TbEntityType entityType, CancellationToken cancel = default);
    
    Task<TbEntityGroup> CreateEntityGroupAsync(TbEntityGroup entityGroup, CancellationToken cancel = default);
}