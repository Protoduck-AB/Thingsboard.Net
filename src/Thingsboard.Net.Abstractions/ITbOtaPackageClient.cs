using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thingsboard.Net;

public interface ITbOtaPackageClient : ITbClient<ITbOtaPackageClient>
{
    Task<TbPage<TbOtaPackage>> GetOtaPackagesAsync(Guid deviceProfileId,   
        string                      type,
        int                         pageSize,
        int                         page,
        string?                     textSearch   = null,
        TbDeviceSearchSortProperty? sortProperty = null,
        TbSortOrder?                sortOrder    = null, 
        CancellationToken           cancel = default);

    Task<TbOtaPackage?> GetOtaPackageInfoByIdAsync(Guid otaPackageId, CancellationToken cancel = default);

}