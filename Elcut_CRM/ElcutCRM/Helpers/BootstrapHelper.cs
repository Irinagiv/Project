using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;

namespace ElcutCRM.Helpers
{
    public static class BootstrapHelper
    {
        public static MvcHtmlString BootstrapActionButton(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, string buttonClass="primary") 
        {
            return htmlHelper.ActionLink(linkText, actionName, routeValues, new { @class = "btn btn-" + buttonClass });
        }

        public static MvcHtmlString BootstrapActionButton(this HtmlHelper htmlHelper, string linkText, string actionName, string controller, object routeValues, string buttonClass = "primary")
        {
            return htmlHelper.ActionLink(linkText, actionName, controller, routeValues, new { @class = "btn btn-" + buttonClass });
        }

        public static MvcHtmlString BootstrapValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var divTag = new TagBuilder("div");

            divTag.AddCssClass("alert");
            divTag.AddCssClass("alert-error");
            divTag.InnerHtml = helper.ValidationMessageFor(expression).ToString();

            return new MvcHtmlString(divTag.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ModalLink(this HtmlHelper helper, string linkText, string actionName, string controllerName, object routeValues, string modalId)
        {
            var link = new TagBuilder("a");
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            link.Attributes.Add("href", urlHelper.Action(actionName, controllerName, routeValues));
            link.Attributes.Add("data-toggle", "modal");
            link.Attributes.Add("data-target", "#" + modalId);
            link.InnerHtml = linkText;

            return new MvcHtmlString(link.ToString(TagRenderMode.Normal));
        }
    }
}