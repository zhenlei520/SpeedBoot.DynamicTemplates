// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.RazorEngine;

public class TemplateProvider : ITemplateProvider
{
    private readonly CustomConcurrentDictionary<string, ITemplateEngineProvider> _data;

    public TemplateProvider()
    {
        _data = new CustomConcurrentDictionary<string, ITemplateEngineProvider>();
    }

    public string Key => RazorEngineGlobalConfig.UniqueId;

    public void Set<TTemplate>(TTemplate template) where TTemplate : Template
    {
        _data.AddOrUpdate(template.Id, id => template is not RazorEngineTemplate razorEngineTemplate ?
            new TemplateEngineProvider(template) :
            new TemplateEngineProvider(razorEngineTemplate));
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
        _data.Remove(id);
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
        if (!_data.TryGet(id, out var templateEngineProvider))
        {
            content = null;
            return false;
        }

        content = templateEngineProvider.Run(metadata);
        return true;
    }

    public void Clear()
    {
        _data.Clear();
    }
}
