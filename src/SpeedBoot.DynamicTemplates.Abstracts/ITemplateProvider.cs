// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.Abstracts;

public interface ITemplateProvider : IService
{
    void Set<TTemplate>(TTemplate template)
        where TTemplate : Template;

    void SetRange<TTemplate>(IEnumerable<TTemplate> template)
        where TTemplate : Template;

    void Delete<TTemplate>(TTemplate template)
        where TTemplate : Template;

    void Delete(string id);

    void DeleteRange(IEnumerable<string> ids);

    bool TryGet<TMetadata>(string id, TMetadata metadata, out string? content);

    void Clear();
}
