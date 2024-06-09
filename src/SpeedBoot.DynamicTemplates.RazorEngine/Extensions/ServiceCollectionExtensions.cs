// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRazorEngine(this IServiceCollection services)
    {
        services.TryAddSingleton<ITemplateProvider, TemplateProvider>();
        return services;
    }
}
