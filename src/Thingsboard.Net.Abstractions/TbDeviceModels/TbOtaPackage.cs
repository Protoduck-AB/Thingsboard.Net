using System;

namespace Thingsboard.Net;

public class TbOtaPackage
{
    public TbOtaPackage(TbEntityId id)
    {
        Id = id;
    }
    
    /// <summary>
    /// Device Id
    /// </summary>
    public TbEntityId Id { get; }
    
    /// <summary>
    /// Created time in js timestamp format.
    /// </summary>
    public DateTime CreatedTime { get; set; }
    
    public TbEntityId? TenantId { get; set; }
    
    public TbEntityId? DeviceProfileId { get; set; }
    
    public string? Type { get; set; }
    
    public string? Title { get; set; }
    
    public string? Version { get; set; }
    
    public string? Tag { get; set; }
    
    public string? Url { get; set; }
    
    public bool? HasData { get; set; }
    
    public string? FileName { get; set; }
    
    public string? ContentType { get; set; }
    
    public string? ChecksumAlgoritm { get; set; }
    
    public string? Checksum { get; set; }
    
    public int? DataSize { get; set; }
    
    public string? Description { get; set; }
    
}