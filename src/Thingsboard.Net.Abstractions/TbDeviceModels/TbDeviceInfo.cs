﻿using System;

namespace Thingsboard.Net;

/// <summary>
/// Device info
/// </summary>
public class TbDeviceInfo
{
    /// <summary>
    /// Device id
    /// </summary>
    public TbEntityId Id { get; }

    /// <summary>
    /// Created time in js timestamp format.
    /// </summary>
    public DateTime CreatedTime { get; }

    public TbEntityId? TenantId { get; }

    public TbEntityId? CustomerId { get; }

    public string? Name { get; }

    public string? Type { get; }

    public string? Label { get; }

    public TbEntityId? DeviceProfileId { get; }

    public TbEntityId? FirmwareId { get; }

    public TbEntityId? SoftwareId { get; }

    public string? CustomerTitle { get; }

    public bool? CustomerIsPublic { get; }

    public string? DeviceProfileName { get; }
    
    public bool? Active { get; }

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public TbDeviceInfo(TbEntityId id,
        DateTime                   createdTime,
        TbEntityId?                tenantId,
        TbEntityId?                customerId,
        string?                    name,
        string?                    type,
        string?                    label,
        TbEntityId?                deviceProfileId,
        TbEntityId?                firmwareId,
        TbEntityId?                softwareId,
        string?                    customerTitle,
        bool?                      customerIsPublic,
        string?                    deviceProfileName,
        bool?                      active)
    {
        Id                = id;
        CreatedTime       = createdTime;
        TenantId          = tenantId;
        CustomerId        = customerId;
        Name              = name;
        Type              = type;
        Label             = label;
        DeviceProfileId   = deviceProfileId;
        FirmwareId        = firmwareId;
        SoftwareId        = softwareId;
        CustomerTitle     = customerTitle;
        CustomerIsPublic  = customerIsPublic;
        DeviceProfileName = deviceProfileName;
        Active            = active;
    }
}
