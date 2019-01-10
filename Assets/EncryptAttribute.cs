using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field |
                AttributeTargets.Property,
    AllowMultiple = true)]
public class EncryptAttribute : Attribute
{
    protected string description;

    public EncryptAttribute(string Description)
    {
        description = Description;
    }
}
