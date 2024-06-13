// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.Abstracts;

public interface ITemplateFacatory
{
    ITemplateProvider Create();

    ITemplateProvider Create(string key);
}
