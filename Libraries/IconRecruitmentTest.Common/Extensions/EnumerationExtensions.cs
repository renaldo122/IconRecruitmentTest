using System;
using System.ComponentModel;

namespace IconRecruitmentTest.Common.Extensions
{
    public static class EnumerationExtensions
    {
        /// <summary>
        /// Extensions to get description attribute based on given enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            if (field == null) return "";
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
