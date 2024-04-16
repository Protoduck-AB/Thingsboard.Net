namespace Thingsboard.Net;

public class TbExtendedUserInfo
{
    public TbExtendedUserInfo(
        TbEntityId           id,
        long                 createdTime,
        TbUserAdditionalInfo additionalInfo,
        TbEntityId           tenantId,
        TbEntityId           customerId,
        string               email,
        string               authority,
        object               firstName,
        object               lastName,
        string               name,
        string               phone,
        TbEntityId           ownerId,
        string               ownerName,
        TbGroup[]            groups
    )
    {
        Id             = id;
        CreatedTime    = createdTime;
        AdditionalInfo = additionalInfo;
        TenantId       = tenantId;
        CustomerId     = customerId;
        Email          = email;
        Authority      = authority;
        FirstName      = firstName;
        LastName       = lastName;
        Name           = name;
        Phone          = phone;
        OwnerId        = ownerId;
        OwnerName      = ownerName;
        Groups         = groups;
    }
    
    public TbEntityId Id { get; }
    public long CreatedTime { get; }
    public TbUserAdditionalInfo AdditionalInfo { get; }
    public TbEntityId TenantId { get; }
    public TbEntityId CustomerId { get; }
    public string Email { get; }
    public string Authority { get; }
    public object FirstName { get; }
    public object LastName { get; }
    public string Name { get; }
    public string Phone { get; }
    public TbEntityId OwnerId { get; }
    public string OwnerName { get; }

    public TbGroup[] Groups { get; }
}

public class TbGroup
{
    public TbGroup(TbEntityId id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public TbEntityId           Id             { get; }
    public string               Name           { get; }
}