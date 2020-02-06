using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatProj.Hubs
{
    public static class IViewExtensions
    {
        public static string GetWebFormViewName(this IView view)
        {
            if (view is WebFormView)
            {
                string viewUrl = ((WebFormView)view).ViewPath;
                string viewFileName = viewUrl.Substring(viewUrl.LastIndexOf('/'));
                string viewFileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(viewFileName);
                return (viewFileNameWithoutExtension);
            }
            else
            {
                throw (new InvalidOperationException("This view is not a WebFormView"));
            }
        }
    }
}