﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates;

public class DynamicTemplateBuilder
{
    public IServiceCollection Services { get; }

    public DynamicTemplateBuilder(IServiceCollection services)
    {
        Services = services;
    }
}
