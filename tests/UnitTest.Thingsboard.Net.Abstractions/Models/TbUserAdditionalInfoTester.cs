using Newtonsoft.Json;
using Thingsboard.Net;
using UnitTest.Thingsboard.Net.Abstractions.Utility.Json;

namespace UnitTest.Thingsboard.Net.Abstractions.Models;

/// <summary>
/// TB sends "lastLoginTs": null for a user who has never logged in (seen on /api/user/{id} in production).
/// </summary>
public class TbUserAdditionalInfoTester
{
    public TbUserAdditionalInfoTester()
    {
        JsonConvert.DefaultSettings = TestJsonSettings.GetJsonSerializerSettings;
    }

    [Fact]
    public void TestReadNullLastLoginTs()
    {
        var json = """{"description":"","userCredentialsEnabled":true,"failedLoginAttempts":0,"lastLoginTs":null}""";

        var info = JsonConvert.DeserializeObject<TbUserAdditionalInfo>(json)!;

        Assert.Null(info.LastLoginTs);
        Assert.True(info.UserCredentialsEnabled);
    }

    [Fact]
    public void TestReadLastLoginTs()
    {
        var json = """{"description":"","userCredentialsEnabled":true,"failedLoginAttempts":0,"lastLoginTs":1793094084000}""";

        var info = JsonConvert.DeserializeObject<TbUserAdditionalInfo>(json)!;

        Assert.Equal(1793094084000, info.LastLoginTs);
    }
}
