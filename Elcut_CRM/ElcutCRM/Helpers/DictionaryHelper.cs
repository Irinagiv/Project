using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ElcutCRM.Data;
using ElcutCRM.Data.Models;
using System.Linq.Expressions;

namespace ElcutCRM.Helpers
{
    public static class DictionaryHelper
    {
        public static MvcHtmlString DictionaryDropDown<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression, string dictionaryName, string firstValue = null, object htmlAttributes = null)
        {
            var manager = new DictionaryManager();

            var selectList = new SelectList(manager.GetAllByDictionary(dictionaryName), "Key", "Name");

            if (firstValue != null)
            {
                var list = selectList.ToList();
                list.Insert(0, new SelectListItem { Text = firstValue, Value = string.Empty });
                selectList = new SelectList(list, "Value", "Text");
            }
            return helper.DropDownListFor(expression, 
                selectList, htmlAttributes);
        }
    }
}