﻿using UnitTest.Thingsboard.Net.Flurl.TbCommon;

namespace UnitTest.Thingsboard.Net.Flurl.TbCustomerClient;

public class GetTenantCustomerTests
{
    [Fact]
    public async Task TestGetTenantCustomer()
    {
        // arrange
        var client = TbTestFactory.Instance.CreateCustomerClient();

        // act
        var actual = await client.GetTenantCustomerAsync(TbTestData.TestCustomerTitle);

        Assert.NotNull(actual);
        Assert.Equal(TbTestData.TestCustomerId, actual!.Id!.Id);
    }

    [Fact]
    public async Task TestWhenCustomerNotFound()
    {
        // arrange
        var client = TbTestFactory.Instance.CreateCustomerClient();

        // act
        var customerId = Guid.Empty;
        var actual     = await client.GetTenantCustomerAsync(Guid.NewGuid().ToString());

        Assert.Null(actual);
    }

    [Fact]
    public async Task TestIncorrectUsername()
    {
        await new TbCommonTestHelper().TestIncorrectUsername(TbTestFactory.Instance.CreateCustomerClient(),
            async client =>
            {
                await client.GetTenantCustomerAsync(TbTestData.TestCustomerTitle);
            });
    }

    [Fact]
    public async Task TestIncorrectBaseUrl()
    {
        await new TbCommonTestHelper().TestIncorrectBaseUrl(TbTestFactory.Instance.CreateCustomerClient(),
            async client =>
            {
                await client.GetTenantCustomerAsync(TbTestData.TestCustomerTitle);
            });
    }
}