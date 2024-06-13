// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDynamicTemplates(this IServiceCollection services, Action<DynamicTemplateBuilder> action)
    {
        if (!ServiceCollectionUtils.TryAdd<RazorEngineProvider>(services))
            return services;

        services.AddSingleton<ITemplateFacatory, TemplateFacatory>();
        services.AddSingleton<ITemplateProvider>(sp => sp.GetRequiredService<ITemplateFacatory>().Create());
        var dynamicTemplateBuilder = new DynamicTemplateBuilder(services);
        action.Invoke(dynamicTemplateBuilder);
        return services;
    }

    private class RazorEngineProvider
    {
    }
}
