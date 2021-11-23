using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCP1_PAW_031.Helper
{
    public static class UrlHelperExtensions
    {
        public static string MakeActive(this IUrlHelper urlHelper, string controller)
        {
            string result = "active";

            string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();

            if (!controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return result;
        }
    }
}
