﻿using System;

using Machine.Specifications;

namespace Machine.Fakes.Internal
{
    /// <summary>
    /// Exception that occurs when a type cannot be instantiated by the automatic faking/dependency resolution
    /// </summary>
    public class InstanceCreationException : SpecificationException
    {
        public InstanceCreationException(Type type, string reason)
            : base(string.Format(
                "Unable to create an instance of type {0}.{1}{2}.",
                type.Name,
                Environment.NewLine,
                reason))
        { }
    }
}