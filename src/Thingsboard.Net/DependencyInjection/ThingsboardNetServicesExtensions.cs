﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Thingsboard.Net.TbAuth;
using Thingsboard.Net.TbEntityQuery;
using Thingsboard.Net.Utility;

namespace Thingsboard.Net.DependencyInjection;

public static class ThingsboardNetServicesExtensions
{
    /// <summary>Adds HTTP Logging services.</summary>
    /// <param name="services">The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" /> for adding services.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="T:Microsoft.AspNetCore.HttpLogging.HttpLoggingOptions" />.</param>
    /// <returns></returns>
    public static IServiceCollection AddThingsboardSdk(
        this IServiceCollection             services,
        Action<ThingsboardNetOptions> configureOptions)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configureOptions == null)
            throw new ArgumentNullException(nameof(configureOptions));

        services.Configure(configureOptions);
        services.AddTransient<IRequestBuilder, FlurlRequestBuilder>();

        services.AddTransient<ITbEntityQuery, FlurlTbEntityQuery>();
        services.AddTransient<ITbAuth, FlurlTbAuth>();
        return services;
    }
}