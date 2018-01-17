﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.WebPages;

namespace v.CMS.Web.Framework
{
    public static class HtmlExtensions
    {
        #region Admin area extensions

        /// <summary>
        /// Render CSS styles of selected index 
        /// </summary>
        /// <param name="helper">HTML helper</param>
        /// <param name="currentTabName">Current tab name (where appropriate CSS style should be rendred)</param>
        /// <param name="title">Tab title</param>
        /// <param name="isDefaultTab">Indicates that the tab is default</param>
        /// <param name="tabNameToSelect">Tab name to select</param>
        /// <param name="customCssClass">Tab name to select</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString RenderBootstrapTabHeader(this HtmlHelper helper, string currentTabName,
            string title, bool isDefaultTab = false, string tabNameToSelect = "", string customCssClass = "")
        {
            if (helper == null)
                throw new ArgumentNullException("helper");

            if (string.IsNullOrEmpty(tabNameToSelect))
                tabNameToSelect = helper.GetSelectedTabName();

            if (string.IsNullOrEmpty(tabNameToSelect) && isDefaultTab)
                tabNameToSelect = currentTabName;

            var a = new TagBuilder("a")
            {
                Attributes =
                {
                    new KeyValuePair<string, string>("data-tab-name", currentTabName),
                    new KeyValuePair<string, string>("href", string.Format("#{0}", currentTabName)),
                    new KeyValuePair<string, string>("data-toggle", "tab"),
                },
                InnerHtml = title
            };
            var liClassValue = "";
            if (tabNameToSelect == currentTabName)
            {
                liClassValue = "active";
            }
            if (!String.IsNullOrEmpty(customCssClass))
            {
                if (!String.IsNullOrEmpty(liClassValue))
                    liClassValue += " ";
                liClassValue += customCssClass;
            }

            var li = new TagBuilder("li")
            {
                Attributes =
                {
                    new KeyValuePair<string, string>("class", liClassValue),
                },
                InnerHtml = a.ToString(TagRenderMode.Normal)
            };

            return MvcHtmlString.Create(li.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Render CSS styles of selected index 
        /// </summary>
        /// <param name="helper">HTML helper</param>
        /// <param name="currentTabName">Current tab name (where appropriate CSS style should be rendred)</param>
        /// <param name="content">Tab content</param>
        /// <param name="isDefaultTab">Indicates that the tab is default</param>
        /// <param name="tabNameToSelect">Tab name to select</param>
        /// <returns>MvcHtmlString</returns>
        public static MvcHtmlString RenderBootstrapTabContent(this HtmlHelper helper, string currentTabName,
            HelperResult content, bool isDefaultTab = false, string tabNameToSelect = "")
        {
            if (helper == null)
                throw new ArgumentNullException("helper");

            if (string.IsNullOrEmpty(tabNameToSelect))
                tabNameToSelect = helper.GetSelectedTabName();

            if (string.IsNullOrEmpty(tabNameToSelect) && isDefaultTab)
                tabNameToSelect = currentTabName;

            var tag = new TagBuilder("div")
            {
                InnerHtml = content.ToHtmlString(),
                Attributes =
                {
                    new KeyValuePair<string, string>("class", string.Format("tab-pane{0}", tabNameToSelect == currentTabName ? " active" : "")),
                    new KeyValuePair<string, string>("id", string.Format("{0}", currentTabName))
                }
            };

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Gets a selected tab name (used in admin area to store selected tab name)
        /// </summary>
        /// <returns>Name</returns>
        public static string GetSelectedTabName(this HtmlHelper helper)
        {
            //keep this method synchornized with
            //"SaveSelectedTab" method of \Administration\Controllers\BaseAdminController.cs
            var tabName = string.Empty;
            const string dataKey = "nop.selected-tab-name";

            if (helper.ViewData.ContainsKey(dataKey))
                tabName = helper.ViewData[dataKey].ToString();

            if (helper.ViewContext.Controller.TempData.ContainsKey(dataKey))
                tabName = helper.ViewContext.Controller.TempData[dataKey].ToString();

            return tabName;
        }

        #endregion
    }
}
