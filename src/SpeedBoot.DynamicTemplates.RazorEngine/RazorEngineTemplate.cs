// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.RazorEngine;

public class RazorEngineTemplate : Template
{
    /// <summary>
    /// Extension Assemblies
    /// </summary>
    public Assembly[]? Assemblies { get; set; } = null;

    public RazorEngineTemplate(string id, string content)
        : base(id, content)
    {
    }

    public RazorEngineTemplate(string id, string content, Assembly[]? assemblies)
        : base(id, content)
    {
        Assemblies = assemblies;
    }
}
