// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates;

public class TemplateFacatory : ITemplateFacatory
{
    private readonly IServiceProvider _serviceProvider;

    public TemplateFacatory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITemplateProvider Create()
        => _serviceProvider.GetRequiredService<ITemplateProvider>(p => true);

    public ITemplateProvider Create(string key)
    {
        return _serviceProvider.GetRequiredService<ITemplateProvider>(key);
    }
}
