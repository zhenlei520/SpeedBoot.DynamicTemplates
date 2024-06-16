// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.RazorEngine;

public class TemplateEngineProvider : ITemplateEngineProvider
{
    private readonly IRazorEngineCompiledTemplate _razorEngineCompiledTemplate;

    public TemplateEngineProvider(Template template)
    {
        var razorEngine = new RazorEngineCore.RazorEngine();
        _razorEngineCompiledTemplate = razorEngine.Compile(template.Content);
    }

    public TemplateEngineProvider(RazorEngineTemplate template)
    {
        var razorEngine = new RazorEngineCore.RazorEngine();
        if (template.Assemblies == null)
        {
            _razorEngineCompiledTemplate = razorEngine.Compile(template.Content);
            return;
        }

        _razorEngineCompiledTemplate = razorEngine.Compile(template.Content, builder =>
        {
            foreach (var assembly in template.Assemblies)
            {
                builder.AddAssemblyReference(assembly);
            }
        });
    }

    public string Key => RazorEngineGlobalConfig.UniqueId;

    public string Run<TMetadata>(TMetadata metadata)
        => _razorEngineCompiledTemplate.Run(metadata);

    public Task<string> RunAsync<TMetadata>(TMetadata metadata)
        => _razorEngineCompiledTemplate.RunAsync(metadata);
}
