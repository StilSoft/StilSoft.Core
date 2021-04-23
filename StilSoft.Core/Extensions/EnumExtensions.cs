using System;
using System.ComponentModel;
using System.Reflection;

namespace StilSoft.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumObject)
        {
            FieldInfo fieldInfo = enumObject.GetType().GetField(enumObject.ToString());
            DescriptionAttribute attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            string description = attribute == null ? enumObject.ToString() : attribute.Description;

            return description;
        }
    }
}