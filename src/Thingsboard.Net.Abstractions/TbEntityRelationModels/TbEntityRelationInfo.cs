using System;

namespace Thingsboard.Net.TbEntityRelationModels;

/// <summary>
/// The entity relation info.
/// </summary>
public class TbEntityRelationInfo
{
    /// <summary>
    /// The from entity id.
    /// </summary>
    public TbEntityId? From { get; set; } = null; // Had to change from Empty to null since empty messed up deserialization

    /// <summary>
    /// The from entity name.
    /// </summary>
    public string? FromName { get; set; }

    /// <summary>
    /// The to entity id.
    /// </summary>
    public TbEntityId? To { get; set; } = null; // Had to change from Empty to null since empty messed up deserialization

    /// <summary>
    /// The to entity name.
    /// </summary>
    public string? ToName { get; set; }

    /// <summary>
    /// The relation type.
    /// </summary>
    public string Type { get; set; } = String.Empty;

    /// <summary>
    /// The additional info.
    /// </summary>
    public object? AdditionalInfo { get; set; }
}
