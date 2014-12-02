using AdopteUneDev.WADAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdopteUneDev.Helper
{
    public static class CustHelper
    {
        /// <summary>
        /// Html helper permettant de créer un tag H1
        /// </summary>
        /// <param name="Origin">la classe helper étendue</param>
        /// <param name="texte">le texte a mettre en H1</param>
        /// <param name="laclasse">la classe du H1 a attribuer</param>
        /// <returns></returns>
        public static MvcHtmlString BoldTitle(this HtmlHelper Origin, string texte, string laclasse)
        {
            TagBuilder ta = new TagBuilder("h1");
            ta.InnerHtml = "<b>"+texte.ToUpper()+"</b>";
            ta.AddCssClass(laclasse);

            return new MvcHtmlString(ta.ToString());
        }

        /// <summary>
        /// Permet d'afficher les catégories de language en respectant les contraintes du template
        /// </summary>
        /// <param name="origin">la classe helper étendue</param>
        /// <param name="categs">La liste des catégories</param>
        /// <returns></returns>
        public static MvcHtmlString MenuCategAndLang(this HtmlHelper origin, IEnumerable<Categories> categs)

        {
            /*Html a générer
             * <div class="panel-group category-products" id="accordian">
             * <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
                                        <span class="badge pull-right"><i class="fa fa-plus"></i></span>
                                        Junior Developer
                                    </a>
                                </h4>
                            </div>
                            <div id="sportswear" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <ul>
                                        <li><a href="#">.NET </a></li>
                                        <li><a href="#">PHP </a></li>
                                        <li><a href="#">HTML5 & CSS3 </a></li>
                                        <li><a href="#">ASP.NET</a></li>
                                        <li><a href="#">JQuery </a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        ...
                    </div>*/
            TagBuilder principal = new TagBuilder("div");
            principal.AddCssClass("category-products");
            principal.AddCssClass("panel-group");        
            principal.Attributes.Add("id", "accordian");

            foreach (Categories CurrentCateg in categs)
            {
                //<div class="panel panel-default">
                TagBuilder DivCateg = new TagBuilder("div");
                DivCateg.AddCssClass("panel-default");
                DivCateg.AddCssClass("panel");
                
                    //<div class="panel-heading">
                    TagBuilder DivHeading = new TagBuilder("div");
                    DivHeading.AddCssClass("panel-heading");
                        // <h4 class="panel-title">
                        TagBuilder H4 = new TagBuilder("h4");
                        H4.AddCssClass("panel-title");
                            //<a data-toggle="collapse" data-parent="#accordian" href="#sportswear">
                            TagBuilder atoggle = new TagBuilder("a");
                            atoggle.Attributes.Add("data-parent", "#accordian");
                            atoggle.Attributes.Add("data-toggle", "collapse");
                            atoggle.Attributes.Add("href", "#" + CurrentCateg.CategLabel.Replace(" ","") );
                                //<span class="badge pull-right"><i class="fa fa-plus"></i></span>
                                    TagBuilder spanbadge = new TagBuilder("span");
                                    spanbadge.AddCssClass("pull-right");
                                    spanbadge.AddCssClass("badge");
                                    spanbadge.InnerHtml = "<i class=\"fa fa-plus\"></i>";
                                   
                           atoggle.InnerHtml=spanbadge.ToString();
                           atoggle.InnerHtml += CurrentCateg.CategLabel;
                        H4.InnerHtml=atoggle.ToString();
                    DivHeading.InnerHtml=H4.ToString();
                 DivCateg.InnerHtml=DivHeading.ToString();
               

                //Ajout des langs
                 // <div id="sportswear" class="panel-collapse collapse">
                 TagBuilder tagLang = new TagBuilder("div");
                 tagLang.Attributes.Add("id", CurrentCateg.CategLabel.Replace(" ", ""));
                 tagLang.AddCssClass("collapse");
                 tagLang.AddCssClass("panel-collapse");
                     //<div class="panel-body">
                     TagBuilder tagBody = new TagBuilder("div");
                     tagBody.AddCssClass("panel-body");
                       //ul
                        TagBuilder tagUl = new TagBuilder("ul");
                         foreach (ITLang item in CurrentCateg.ItLangs)
                         {
                             TagBuilder tagLi = new TagBuilder("li");
                             tagLi.InnerHtml = "<a href=\"#\">" + item.ITLabel + "</a>";
                            //Ajout au ul
                             tagUl.InnerHtml += tagLi;
                     
                         }
                     tagBody.InnerHtml = tagUl.ToString();
                 tagLang.InnerHtml = tagBody.ToString();
                //Ajout categ
                 DivCateg.InnerHtml += tagLang.ToString();
                 //Ajout au principal
                 principal.InnerHtml += DivCateg.ToString();
                 
            }

            return new MvcHtmlString(principal.ToString());
        }
       
        /// <summary>
        /// Permet de mettre en place le menu des languages + le nombre de dev dispo
        /// </summary>
        /// <param name="origin">la classe helper étendue</param>
        /// <param name="langs">La liste des languages IT</param>
        /// <returns></returns>
        public static MvcHtmlString MenuDevAndLang(this HtmlHelper origin, IEnumerable<ITLang> langs)
        {
          /*  <ul class="nav nav-pills nav-stacked">
                                <li><a href="#"> <span class="pull-right">(50)</span>.NET</a></li>
                                <li><a href="#"> <span class="pull-right">(56)</span>PHP</a></li>
                                <li><a href="#"> <span class="pull-right">(27)</span>JAVA</a></li>
                                <li><a href="#"> <span class="pull-right">(32)</span>ANDROID</a></li>
                                <li><a href="#"> <span class="pull-right">(5)</span>JQuery</a></li>
                            </ul>*/
            TagBuilder ta = new TagBuilder("ul");
            ta.AddCssClass("nav-stacked");
            ta.AddCssClass("nav-pills");
            ta.AddCssClass("nav");
            foreach (ITLang item in langs)
            {
                TagBuilder tli = new TagBuilder("li");
                TagBuilder ah = new TagBuilder("a");
                    TagBuilder tspan = new TagBuilder("span");
                    tspan.AddCssClass("pull-right");
                    tspan.InnerHtml = "(" + item.Developers.Count().ToString() + ")";
                    ah.InnerHtml = tspan.ToString();
                    ah.InnerHtml += item.ITLabel.Replace(" ", "");
                    tli.InnerHtml = ah.ToString();
                ta.InnerHtml += tli.ToString();
            }
            return new MvcHtmlString(ta.ToString());

        }


        #region NOT READ
        //public static MvcHtmlString DeveloperOfTheMonth(this HtmlHelper origin, IEnumerable<Developer> devs)
        //{
        //    string returnStr = "";
        //    foreach (Developer CurrentDev in devs)
        //    {

        //        returnStr += RenderViewToString((ControllerContext)HttpContext.Current.Session["ControllerContext"], "_DevDisplay", CurrentDev);
        //    }
        //    return new MvcHtmlString(returnStr);
        //}


        //public static string RenderViewToString(ControllerContext context, string viewName, object model)
        //{
        //    if (string.IsNullOrEmpty(viewName))
        //        viewName = context.RouteData.GetRequiredString("action");

        //    var viewData = new ViewDataDictionary(model);

        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
        //        var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
        //        viewResult.View.Render(viewContext, sw);

        //        return sw.GetStringBuilder().ToString();
        //    }
        //} 
        #endregion
    }
}