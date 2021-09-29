using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace StilSoft.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            string description = attribute == null ? value.ToString() : attribute.Description;

            return description;
        }
        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            return type.GetField(name).GetCustomAttribute<TAttribute>();
        }

        public static IEnumerable<Attribute> GetAttributes(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            return type.GetField(name).GetCustomAttributes();
        }
    }
}