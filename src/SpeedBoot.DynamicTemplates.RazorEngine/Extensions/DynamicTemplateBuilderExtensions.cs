// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates;

public static class DynamicTemplateBuilderExtensions
{
    public static DynamicTemplateBuilder UseRazorEngine(this DynamicTemplateBuilder builder)
    {
        return builder.UseRazorEngine(StringComparer.OrdinalIgnoreCase);
    }

    public static DynamicTemplateBuilder UseRazorEngine(this DynamicTemplateBuilder builder, IEqualityComparer<string>? comparer)
    {
        if (!ServiceCollectionUtils.TryAdd<RazorEngineProvider>(builder.Services))
            return builder;

        builder.Services.AddTransient<ITemplateProvider>(sp=> new TemplateProvider(comparer));
        return builder;
    }

    private class RazorEngineProvider
    {
    }
}
