﻿using System;
using Thingsboard.Net.Models;

namespace Thingsboard.Net.TbEntityQuery;

/// <summary>
/// Single entity filter
/// </summary>
public class TbSingleEntityFilter : TbEntityFilter
{
    public override string Type => "singleEntity";

    public TbEntityId? SingleEntity { get; set; }

    public TbSingleEntityFilter()
    {
    }

    public TbSingleEntityFilter(TbEntityType entityType, Guid entityId)
    {
        SingleEntity = new TbEntityId(entityType, entityId);
    }
}
