#pragma checksum "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\NutritionistArticles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d71810701d14b3026ff5d559de946d8b8ff64e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nutritionist_NutritionistArticles), @"mvc.1.0.view", @"/Views/Nutritionist/NutritionistArticles.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\_ViewImports.cshtml"
using Nutritionist.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\_ViewImports.cshtml"
using Nutritionist.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d71810701d14b3026ff5d559de946d8b8ff64e1", @"/Views/Nutritionist/NutritionistArticles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b391ab0ce3fe424f8f534bed9a7099d3b3838174", @"/Views/_ViewImports.cshtml")]
    public class Views_Nutritionist_NutritionistArticles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Nutritionist.Core.Models.Article.List>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\NutritionistArticles.cshtml"
  
    ViewData["Title"] = "Makalelerim";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""gallery3 cid-smamM4w0M4"" id=""gallery3-9"">


    <div class=""container-fluid"">
        <div class=""mbr-section-head"">
            <h4 class=""mbr-section-title mbr-fonts-style align-center mb-0 display-2""><strong>Makalelerim</strong></h4>

        </div>
        ");
#nullable restore
#line 15 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\NutritionistArticles.cshtml"
   Write(Html.Partial("~/Views/Shared/ArticleListPartial.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    </div>\r\n</section>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Nutritionist.Core.Models.Article.List>> Html { get; private set; }
    }
}
#pragma warning restore 1591
