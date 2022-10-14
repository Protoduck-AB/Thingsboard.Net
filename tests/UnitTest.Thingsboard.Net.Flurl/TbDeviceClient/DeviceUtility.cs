﻿using Thingsboard.Net;

namespace UnitTest.Thingsboard.Net.Flurl.TbDeviceClient;

public class DeviceUtility
{
    public static TbDevice GenerateEntity()
    {
        var device = new TbDevice
        {
            Name            = Guid.NewGuid().ToString(),
            Type            = "Test Device Type",
            Label           = "Test Device Label",
            DeviceProfileId = new TbEntityId(TbEntityType.DEVICE_PROFILE, TbTestData.TestDeviceProfileId),
        };

        return device;
    }

    public static async Task<TbDevice> CreateDeviceAsync()
    {
        var client = TbTestFactory.Instance.CreateDeviceClient();
        var device = GenerateEntity();
        return await client.SaveDeviceAsync(device);
    }
}