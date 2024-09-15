using System;

namespace RadioBrowserWrapper.Enums
{
    /// <summary>
    /// Represents an attribute for enum members to specify their value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class EnumMemberValueAttribute : Attribute
    {
        public string Value { get; }

        public EnumMemberValueAttribute(string value)
        {
            Value = value;
        }
    }
}
