namespace Thingsboard.Net;

public class TbSaveUserRequest
{
    public TbSaveUserRequest(
        TbEntityId id,
        TbEntityId tenantId,
        TbEntityId customerId,
        string email,
        string authority,
        object firstName,
        object lastName,
        string phone,
        TbEntityId ownerId,
        object additionalInfo
    )
    {
        Id = id;
        TenantId = tenantId;
        CustomerId = customerId;
        Email = email;
        Authority = authority;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        OwnerId = ownerId;
        AdditionalInfo = additionalInfo;
    }
    
    public TbEntityId Id { get; }
    public TbEntityId TenantId { get; }
    public TbEntityId CustomerId { get; }
    
    public string Email { get; }
    
    public string Authority { get; }
    
    public object FirstName { get; }
    
    public object LastName { get; }
    public string Phone { get; }
    public TbEntityId OwnerId { get; }
    public object AdditionalInfo { get; }
}