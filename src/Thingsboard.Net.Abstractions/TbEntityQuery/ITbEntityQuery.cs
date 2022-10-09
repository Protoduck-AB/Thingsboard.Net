﻿using System.Threading;
using System.Threading.Tasks;
using Thingsboard.Net.Common;
using Thingsboard.Net.Models;

namespace Thingsboard.Net.TbEntityQuery;

public interface ITbEntityQuery : IClientApi<ITbEntityQuery>
{
    /// <summary>
    /// Allows to run complex queries over platform entities (devices, assets, customers, etc) based on the combination of main entity filter and multiple key filters. Returns the paginated result of the query that contains requested entity fields and latest values of requested attributes and time-series data.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    Task<TbPage<TbEntity>> FindEntityDataByQueryAsync(TbFindEntityDataRequest request, CancellationToken cancel = default);

    /// <summary>
    /// Allows to run complex queries to search the count of platform entities (devices, assets, customers, etc) based on the combination of main entity filter and multiple key filters. Returns the number of entities that match the query definition.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancel"></param>
    /// <returns></returns>
    Task<int> CountEntityDataByQueryAsync(TbCountEntityDataRequest request, CancellationToken cancel = default);
}