// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.Abstracts;

public class Template
{
    public string Id { get; set; }

    public string Content { get; set; }

    /// <summary>
    /// Extension Assemblies
    /// </summary>
    public Assembly[]? Assemblies { get; set; } = null;

    public Template()
    {
    }

    public Template(string id, string content)
        : this(id, content, null)
    {
    }

    public Template(string id, string content, Assembly[]? assemblies)
    {
        Id = id;
        Content = content;
        Assemblies = assemblies;
    }
}
