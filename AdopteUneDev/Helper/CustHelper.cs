using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Helper
{
    public static class CustHelper
    {
        public static MvcHtmlString BoldTitle(this HtmlHelper Origin, string texte, string laclasse)
        {
            TagBuilder ta = new TagBuilder("h1");
            ta.InnerHtml = texte.ToUpper();
            ta.AddCssClass(laclasse);

            return new MvcHtmlString(ta.ToString());
        }
    }
}