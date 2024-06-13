// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.RazorEngine;

public class TemplateProvider : ITemplateProvider
{
    private readonly IRazorEngine _razorEngine;
    private readonly CustomConcurrentDictionary<string, IRazorEngineCompiledTemplate> _templateData;

    public TemplateProvider()
    {
        _razorEngine = new RazorEngineCore.RazorEngine();
        _templateData = new CustomConcurrentDictionary<string, IRazorEngineCompiledTemplate>();
    }

    public string Key => RazorEngineGlobalConfig.UniqueId;

    public void Set<TTemplate>(TTemplate template) where TTemplate : Template
    {
        _templateData.AddOrUpdate(template.Id, id =>
        {
            if (template.Assemblies == null)
                return _razorEngine.Compile(template.Content);
            return _razorEngine.Compile(template.Content, builder =>
            {
                foreach (var assembly in template.Assemblies)
                {
                    builder.AddAssemblyReference(assembly);
                }
            });
        });
    }

    public void SetRange<TTemplate>(IEnumerable<TTemplate> templates) where TTemplate : Template
    {
        foreach (var template in templates)
        {
            Set(template);
        }
    }

    public void Delete<TTemplate>(TTemplate template) where TTemplate : Template
    {
        Delete(template.Id);
    }

    public void Delete(string id)
    {
        _templateData.Remove(id);
    }

    public void DeleteRange(IEnumerable<string> ids)
    {
        foreach (var id in ids)
        {
            Delete(id);
        }
    }

    public bool TryGet<TMetadata>(string id, TMetadata metadata, out string? content)
    {
        if (!_templateData.TryGet(id, out var engineCompiledTemplate))
        {
            content = null;
            return false;
        }

        content = engineCompiledTemplate.Run(metadata);
        return true;
    }

    public void Clear()
    {
        _templateData.Clear();
    }
}
