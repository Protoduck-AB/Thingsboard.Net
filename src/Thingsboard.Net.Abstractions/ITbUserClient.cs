using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thingsboard.Net;

public interface ITbUserClient : ITbClient<ITbUserClient>
{
    Task<TbExtendedUserInfo?> GetExtendedUserInfo(Guid userId, CancellationToken cancel = default);
    Task<TbExtendedUserInfo> SaveUser(bool sendActivationMail, string entityGroupId, string entityGroupIds, TbExtendedUserInfo request, CancellationToken cancel = default);
    Task<string> GetActivationLink(Guid userId, CancellationToken cancel = default);

    Task<TbPage<TbExtendedUserInfo>> GetCustomerUserInfos(Guid customerId,
        int pageSize,
        int page,
        bool? includeCustomers = null,
        string? textSearch = null,
        TbUserSearchSortProperty? sortProperty = null,
        TbSortOrder? sortOrder = null,
        CancellationToken cancel = default);
    
    Task<TbPage<TbExtendedUserInfo>> GetUsersByEntityGroupId(Guid entityGroupId,
        int pageSize,
        int page,
        bool? includeCustomers = null,
        string? textSearch = null,
        TbUserSearchSortProperty? sortProperty = null,
        TbSortOrder? sortOrder = null,
        CancellationToken cancel = default);
    
    Task<TbPage<TbUserInfo>> GetUsers(
        int pageSize, 
        int page, 
        string? textSearch = null, 
        TbUserSearchSortProperty? sortProperty = null,
        TbSortOrder? sortOrder = null,
        CancellationToken cancel = default);
    
    Task<TbPage<TbExtendedUserInfo>> GetResellerUsers(
        int pageSize, 
        int page, 
        string? textSearch = null, 
        TbUserSearchSortProperty? sortProperty = null,
        TbSortOrder? sortOrder = null,
        CancellationToken cancel = default);
    
    Task ActivateUser(string activateToken, string password, bool sendActivationMail = false, CancellationToken cancel = default);
    
    Task DeleteUser(Guid userId, CancellationToken cancel = default);
}