// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates;

public static class DynamicTemplateBuilderExtensions
{
    public static DynamicTemplateBuilder UseRazorEngine(this DynamicTemplateBuilder builder)
    {
        if (!ServiceCollectionUtils.TryAdd<RazorEngineProvider>(builder.Services))
            return builder;

        builder.Services.AddTransient<ITemplateProvider, TemplateProvider>();
        return builder;
    }

    private class RazorEngineProvider
    {
    }
}
