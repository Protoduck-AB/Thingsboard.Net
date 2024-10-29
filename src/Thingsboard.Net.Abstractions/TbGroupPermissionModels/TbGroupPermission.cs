using System;

namespace Thingsboard.Net.TbGroupPermissionModels;

public class TbGroupPermissionRequest
{
    public TbEntityId UserGroupId { get; set; }
    public TbEntityId EntityGroupOwnerId { get; set; }
    public TbGroupPermissionRole Role { get; set; }
    public TbEntityId? EntityGroupId { get; set; }
    public TbEntityId? UserGroupOwnerId { get; set; }
    public TbEntityId RoleId { get; set; }
    public string? EntityGroupType { get; set; }
}

// {
// "tenantId": {
//     "entityType": "TENANT",
//     "id": "c70eb9f0-6908-11ee-843f-ebc9ee005c11"
// },
// "userGroupId": {
//     "entityType": "ENTITY_GROUP",
//     "id": "ae693000-9531-11ef-bd51-a5cb262ce3df"
// },
// "roleId": {
//     "entityType": "ROLE",
//     "id": "f00e3ff0-6a48-11ef-bd51-a5cb262ce3df"
// },
// "entityGroupId": null,
// "entityGroupType": null,
// "id": {
//     "entityType": "GROUP_PERMISSION",
//     "id": "3c4bf8d0-9532-11ef-bd51-a5cb262ce3df"
// },
// "createdTime": 1730122846429,
// "name": "GENERIC_[ae693000-9531-11ef-bd51-a5cb262ce3df]_[f00e3ff0-6a48-11ef-bd51-a5cb262ce3df]",
// "public": false
// }

public class TbGroupPermissionResponse
{
    public TbEntityId TenantId { get; set; }
    public TbEntityId? UserGroupId { get; set; }
    public TbEntityId? RoleId { get; set; }
    public TbEntityId? EntityGroupId { get; set; }
    public string? EntityGroupType { get; set; }
    public TbEntityId Id { get; set; }
    public DateTime? CreatedTime { get; set; }
    public string? Name { get; set; }
    public bool Public { get; set; }
}
    