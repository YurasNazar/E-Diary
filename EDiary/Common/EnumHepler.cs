using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Common
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Returns the value of the Description attribute on the enum, otherwise an empty string. E.g. GetEnumDescription&lt;CustomerStatus&gt;((CustomerStatus)person.StatusId)
        /// </summary>
        /// <typeparam name="T">The Type of the enum</typeparam>
        /// <param name="value">The value of the enum</param>
        /// <returns>The description string from the DescriptionAttribute</returns>
        public static string GetEnumDescription<T>(T value)
        {
            var t = typeof(T);
            if (!t.IsEnum)
            {
                throw new InvalidCastException("This method expects an enum type");
            }

            var fi = value.GetType().GetField(value.ToString());
            if (fi == null)
            {
                return string.Empty;
            }

            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : string.Empty;
        }

        /// <summary>
        /// Returns the value of the EnumStringAttribute attribute on the enum, otherwise an empty string. E.g. GetEnumCustomStringAttribute&lt;CustomerStatus&gt;((CustomerStatus)person.StatusId)
        /// </summary>
        /// <typeparam name="T">The Type of the enum</typeparam>
        /// <param name="value">The value of the enum</param>
        /// <returns>The description string from the EnumStringAttribute</returns>
        public static string GetEnumCustomStringAttribute<T>(T value)
        {
            var t = typeof(T);
            if (!t.IsEnum)
            {
                throw new InvalidCastException("This method expects an enum type");
            }

            var fi = value.GetType().GetField(value.ToString());
            if (fi == null)
            {
                return string.Empty;
            }

            var attrs = fi.GetCustomAttributes(typeof(Extensions.EnumStringAttribute), true);
            return attrs.Length > 0 ? ((Extensions.EnumStringAttribute)attrs[0]).StringValue : string.Empty;
        }

        public static List<KeyValuePair<int, string>> GetEnumKeyValuePairList<TEnum>(params TEnum[] exclude)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            if (exclude != null && exclude.Any())
            {
                enumValues = enumValues.Where(x => !exclude.Contains(x));
            }

            return enumValues
                .Select(x => new KeyValuePair<int, string>(x.ToInt32(CultureInfo.InvariantCulture), x.ToString()))
                .ToList();
        }

        ///// <summary>
        ///// Get localized list of SelectListItem for enum (applicable for razor select)
        ///// </summary>
        ///// <typeparam name="TEnum">Enum type</typeparam>
        ///// <param name="exclude">Arrays of TEnum values to exclude</param>
        ///// <returns></returns>
        //public static IList<SelectListItem> GetEnumSelectListItemList<TEnum>(params TEnum[] exclude)
        //    where TEnum : struct, IConvertible
        //{
        //    if (!typeof(TEnum).IsEnum)
        //    {
        //        throw new ArgumentException("T must be an enumerated type");
        //    }

        //    var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

        //    if (exclude != null && exclude.Any())
        //    {
        //        enumValues = enumValues.Where(x => !exclude.Contains(x));
        //    }

        //    return enumValues
        //                    .Select(x => new SelectListItem
        //                    {
        //                        Text = x.GetLocalizedEnum(),
        //                        Value = x.ToInt32(CultureInfo.InvariantCulture).ToString()
        //                    }).ToList();
        //}

        ///// <summary>
        ///// Get localized list of key/value pairs specified enum values
        ///// </summary>
        ///// <param name="include">values to get list of</param>
        ///// <returns></returns>
        //public static List<KeyValuePair<int, string>> GetEnumKeyValuePairListInclude<TEnum>(params TEnum[] include)
        //    where TEnum : struct, IConvertible
        //{
        //    if (include.Any() && !include.First().GetType().IsEnum)
        //    {
        //        throw new ArgumentException("T must be an enumerated type");
        //    }

        //    return include.Select(x => new KeyValuePair<int, string>(x.ToInt32(CultureInfo.InvariantCulture), x.GetLocalizedEnum())).ToList();
        //}


        //public static T GetValueFromDescription<T>(string description)
        //{
        //    var type = typeof(T);
        //    if (!type.IsEnum)
        //    {
        //        throw new InvalidOperationException();
        //    }

        //    foreach (var field in type.GetFields())
        //    {
        //        if (Attribute.GetCustomAttribute(field,
        //            typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
        //        {
        //            if (attribute.Description == description)
        //            {
        //                return (T)field.GetValue(null);
        //            }
        //        }
        //        else
        //        {
        //            if (field.Name == description)
        //            {
        //                return (T)field.GetValue(null);
        //            }
        //        }
        //    }

        //    return default(T);
        //}
    }
}
