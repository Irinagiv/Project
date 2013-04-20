using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ElcutCRM.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<string> GetLocalizedNames(Type enumType)
        {
            var enumNames = Enum.GetNames(enumType);

            foreach (var name in enumNames)
            {
                var field = enumType.GetField(name);

                var display = ((DisplayAttribute[])field.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();

                if (display != null)
                {
                    yield return display.Name;
                    continue;
                }

                yield return name;
            }
        }

        public static IEnumerable<SelectListItem> GetLocalizedSelectListItems(Type enumType)
        {
            var enumNames = Enum.GetNames(enumType);

            foreach (var name in enumNames)
            {
                var field = enumType.GetField(name);

                var display = ((DisplayAttribute[])field.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();

                if (display != null)
                {
                    yield return new SelectListItem { Text = display.Name, Value = name };
                    continue;
                }

                yield return new SelectListItem { Text = name, Value = name }; ;
            }
        }
    }
}