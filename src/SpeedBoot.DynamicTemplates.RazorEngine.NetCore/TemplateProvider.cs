// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.RazorEngine.NetCore;

public class TemplateProvider : ITemplateProvider
{
    private readonly CustomConcurrentDictionary<string, IRazorEngineService> _templateData;

    public string Key => RazorEngineNetCoreGlobalConfig.UniqueId;

    public void Set<TTemplate>(TTemplate template) where TTemplate : Template
    {
        throw new NotImplementedException();
    }

    public void SetRange<TTemplate>(IEnumerable<TTemplate> template) where TTemplate : Template
    {
        throw new NotImplementedException();
    }

    public void Delete<TTemplate>(TTemplate template) where TTemplate : Template
    {
        throw new NotImplementedException();
    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(IEnumerable<string> ids)
    {
        throw new NotImplementedException();
    }

    public bool TryGet<TMetadata>(string id, TMetadata metadata, out string? content)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
}
