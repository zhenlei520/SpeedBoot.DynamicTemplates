// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace SpeedBoot.DynamicTemplates.Abstracts;

public class Template
{
    /// <summary>
    /// template id
    /// No Duplicates Allowed
    /// </summary>
    public string Id { get; set; }

    public string Content { get; set; }

    public Template()
    {
    }

    public Template(string id, string content) : this()
    {
        Id = id;
        Content = content;
    }
}
