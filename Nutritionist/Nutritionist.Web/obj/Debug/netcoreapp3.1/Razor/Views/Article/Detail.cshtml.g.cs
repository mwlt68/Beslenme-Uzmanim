#pragma checksum "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72d0a25c59b90401cdd70a74bdbf629c826d09cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article_Detail), @"mvc.1.0.view", @"/Views/Article/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72d0a25c59b90401cdd70a74bdbf629c826d09cb", @"/Views/Article/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b391ab0ce3fe424f8f534bed9a7099d3b3838174", @"/Views/_ViewImports.cshtml")]
    public class Views_Article_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Nutritionist.Core.Models.Article.Detail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<section class=\"image1 cid-snKxmdOxCx\" id=\"image1-1a\">\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row align-items-center\">\r\n            <div class=\"col-12 col-lg-6\">\r\n                <div class=\"image-wrapper\">\r\n");
#nullable restore
#line 15 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
                     if (Model.Image != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 462, "\"", 527, 2);
            WriteAttributeValue("", 468, "data:image/jpg;base64,", 468, 22, true);
#nullable restore
#line 17 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
WriteAttributeValue(" ", 490, Convert.ToBase64String(Model.Image), 491, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 18 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <p class=""mbr-description mbr-fonts-style pt-2 align-center display-4""></p>
                </div>
            </div>
            <div class=""col-12 col-lg"">
                <div class=""text-wrapper"">
                    <h3 class=""mbr-section-title mbr-fonts-style mb-3 display-5"">
                        <strong>");
#nullable restore
#line 25 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
                           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                    </h3>\r\n\r\n                    <div class=\"row pt-1\">\r\n\r\n                        <div class=\"container\">\r\n                            <i>");
#nullable restore
#line 31 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
                          Write(Model.UpdateDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i> \r\n                        </div>\r\n                        <div class=\"container pt-3\">\r\n                            <a class=\"beautyLink\" href=\"asdasd\">\r\n                                ");
#nullable restore
#line 35 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
                           Write(Model.Nutritionist.User.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </a>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</section>

<section class=""content5 cid-snKxuM5n0n"" id=""content5-1b"">

    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-md-12 col-lg-10"">

                <h4 class=""mbr-section-subtitle mbr-fonts-style mb-4 display-5""></h4>
                <p class=""mbr-text mbr-fonts-style display-7"">
                    ");
#nullable restore
#line 54 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Article\Detail.cshtml"
               Write(Model.Body);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Nutritionist.Core.Models.Article.Detail> Html { get; private set; }
    }
}
#pragma warning restore 1591
