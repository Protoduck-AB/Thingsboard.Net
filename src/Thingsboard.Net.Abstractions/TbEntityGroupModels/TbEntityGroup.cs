using System;
using System.Collections.Generic;

namespace Thingsboard.Net.TbEntityGroupModels;

public class TbEntityGroup
{
  public TbEntityGroup(TbEntityId id)
  {
      Id = id;
  }
  
  /// <summary>
  /// Entity Group Id
  /// </summary>
  public TbEntityId Id { get; }
  
  /// <summary>
  /// Created time in js timestamp format.
  /// </summary>
  public DateTime CreatedTime { get; set; }
  
  public TbEntityId OwnerId { get; set; }
  
  public string? Name { get; set; }

  public string? Type { get; set; }
  
  /// <summary>
  /// optional, defines additional infos for the entity group
  /// </summary>
  public Dictionary<string, object?> AdditionalInfo { get; } = new();


  public object? Configuration { get; } = null;

  public bool GroupAll { get; } = false;
  
  public bool EdgeGroupAll { get; } = false;
  
  public List<TbEntityId> OwnerIds { get; } = [];
}