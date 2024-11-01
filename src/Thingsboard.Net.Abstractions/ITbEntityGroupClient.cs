using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thingsboard.Net.TbEntityGroupModels;

namespace Thingsboard.Net;

public interface ITbEntityGroupClient : ITbClient<ITbEntityGroupClient>
{
    Task<TbEntityGroup[]> GetEntityGroupsByOwnerAndTypeAsync(TbEntityType ownerType, Guid ownerId, TbEntityType entityType, CancellationToken cancel = default);
    
    Task<TbEntityGroup> CreateEntityGroupAsync(TbEntityGroup entityGroup, CancellationToken cancel = default);
    
    Task AddUsersToEntityGroupAsync(Guid entityGroupId, List<Guid> userIds, CancellationToken cancel = default);
    Task DeleteUsersFromEntityGroupAsync(Guid entityGroupId,  List<Guid> userIds, CancellationToken cancel = default);
}