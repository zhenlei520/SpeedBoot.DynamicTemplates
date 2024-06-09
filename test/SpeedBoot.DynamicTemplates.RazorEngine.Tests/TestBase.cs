// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.RazorEngine.Tests;

public abstract class TestBase
{
    /// <summary>
    /// Service Collections
    /// </summary>
    protected IServiceCollection Services;

    public TestBase()
    {
        Services = new ServiceCollection();
        var applicationBuilder = Services.AddSpeedBoot(options =>
        {
            options.Assemblies = AppDomain.CurrentDomain.GetAssemblies().Concat(new Assembly[]
            {
                typeof(DefaultAutoInjectProvider).Assembly,
                typeof(ITemplateProvider).Assembly,
                typeof(TemplateProvider).Assembly
            }).ToArray();
        });
        applicationBuilder.Build();
        applicationBuilder.SetRootServiceProvider(Services.BuildServiceProvider());
    }
}
