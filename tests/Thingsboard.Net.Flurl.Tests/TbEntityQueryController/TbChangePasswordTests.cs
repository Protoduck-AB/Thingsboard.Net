﻿using Thingsboard.Net.Models;
using Thingsboard.Net.TbEntityQuery;

namespace Thingsboard.Net.Tests.TbEntityQuery;

/// <summary>
/// This class is used to test change password functionality
/// </summary>
public class FindEntityDataByQueryTests
{
    [Fact]
    public async Task TestFindEntityDataByQuery()
    {
        using var service = new TbTestService();
        var       api     = service.GetRequiredService<ITbEntityQuery>();

        var result = await api.FindEntityDataByQueryAsync(new TbFindEntityDataRequest
        {
            EntityFilter = new TbSingleEntityFilter(TbEntityType.TENANT, Guid.NewGuid()),
            EntityFields = new[] {new TbEntityField("id", TbEntityFieldType.ENTITY_FIELD)},
            PageLink = new TbEntityDataPageLink
            {
                Page     = 0,
                PageSize = 20,
            }
        });

        Assert.NotNull(result);
    }
}
