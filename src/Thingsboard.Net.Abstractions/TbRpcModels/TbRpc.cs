﻿using System;
using System.Collections.Generic;

namespace Thingsboard.Net;

public class TbRpc
{
    public TbEntityId? Id { get; set; }

    public DateTime? CreatedTime { get; set; }

    public TbEntityId? TenantId { get; set; }

    public TbEntityId? DeviceId { get; set; }

    public int? ExpirationTime { get; set; }

    public Dictionary<string, object>? Request { get; set; }

    public Dictionary<string, object>? Response { get; set; }

    public string? Status { get; set; }

    public Dictionary<string, object>? AdditionalInfo { get; set; }
}