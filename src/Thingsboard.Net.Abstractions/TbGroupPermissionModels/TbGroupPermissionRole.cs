namespace Thingsboard.Net.TbGroupPermissionModels;

public class TbGroupPermissionRole()
{
    public RoleType Role { get; set; }
    public TbEntityId Id { get; set; }
}

public enum RoleType
{
    GENERIC,
    GROUP
}