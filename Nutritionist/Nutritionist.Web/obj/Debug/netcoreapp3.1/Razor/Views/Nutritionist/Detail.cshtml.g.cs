#pragma checksum "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf7dd39c092cef3d6e2f42c86454f1fcdd88bbb6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nutritionist_Detail), @"mvc.1.0.view", @"/Views/Nutritionist/Detail.cshtml")]
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
#nullable restore
#line 2 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf7dd39c092cef3d6e2f42c86454f1fcdd88bbb6", @"/Views/Nutritionist/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b391ab0ce3fe424f8f534bed9a7099d3b3838174", @"/Views/_ViewImports.cshtml")]
    public class Views_Nutritionist_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Nutritionist.Web.Models.ApiModelsCombines.NutritionistContDetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Nutritionist", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mbr-form form-with-styler mx-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CommentDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Yorumunuzu kaldırmak istediginden emin misin ?\',);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/web/assets/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int userIdSession = -1, nutritionistIdSession = -1;
    if (Context.Session.GetInt32("UserId").HasValue)
    {
        userIdSession = Context.Session.GetInt32("UserId").Value;
    }
    if (Context.Session.GetInt32("NutId").HasValue)
    {
        nutritionistIdSession = Context.Session.GetInt32("NutId").Value;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"testimonials1 cid-smbkrMBl7x\" id=\"testimonials1-t\">\r\n\r\n\r\n\r\n    <div class=\"container\">\r\n\r\n        <div class=\"row align-items-center\">\r\n            <div class=\"col-12 col-md-4\">\r\n                <div class=\"image-wrapper\">\r\n");
#nullable restore
#line 34 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                     if (@Model.nutritionist.ProfileImage != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 1035, "\"", 1111, 2);
            WriteAttributeValue("", 1041, "data:image/jpg;base64,", 1041, 22, true);
#nullable restore
#line 36 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
WriteAttributeValue(" ", 1063, ArrayToBase64(Model.nutritionist.ProfileImage), 1064, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:300px;height:300px\">\r\n");
#nullable restore
#line 37 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"col-12 col-md\">\r\n                <center class=\"text-wrapper\">\r\n                    <p class=\"name mbr-fonts-style mb-1 display-2\" style=\"color:green\">\r\n                        <strong>");
#nullable restore
#line 43 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                           Write(Model.nutritionist.User.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                    </p>\r\n                    <p class=\"position mbr-fonts-style display-5 pt-4\">\r\n                        <strong>");
#nullable restore
#line 46 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                           Write(Model.nutritionist.Departman);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                    </p>\r\n                    <p class=\"mbr-text mbr-fonts-style mb-4 display-7\">");
#nullable restore
#line 48 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                                                  Write(Model.nutritionist.ShortIntroduce);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </center>
            </div>
        </div>
    </div>
</section>

<section class=""content6 cid-smbobpfXlF"" id=""content6-14"">

    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-md-12"">
                <hr class=""line"">
                <pre class=""mbr-text align-center mbr-fonts-style my-4 display-7"" style=""white-space:pre-wrap"">
                <em>
                        ");
#nullable restore
#line 63 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                   Write(Html.Raw(Model.nutritionist.Introduce));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </em>
                </pre>
                <hr class=""line"">
            </div>
        </div>
    </div>
</section>

<section class=""contacts2 cid-smbkxOO1Bv"" id=""contacts2-v"">
    <!---->


    <div class=""container"">
        <div class=""mbr-section-head"">
            <h3 class=""mbr-section-title mbr-fonts-style align-center mb-0 display-2"">
                <strong>Bağlantılar</strong>
            </h3>

        </div>
        <div class=""row justify-content-center mt-4"">
            <div class=""card col-12 col-md-6"">
                <div class=""card-wrapper"">
                    <div class=""image-wrapper"">
                        <span class=""mbr-iconfont mobi-mbri-phone mobi-mbri""></span>
                    </div>
                    <div class=""text-wrapper"">
                        <h6 class=""card-title mbr-fonts-style mb-1 display-5"">
                            <strong>Telefon</strong>
                        </h6>
                        <p class=");
            WriteLiteral("\"mbr-text mbr-fonts-style display-7\">\r\n                            <a href=\"tel:+12345678910\" class=\"text-primary\">");
#nullable restore
#line 94 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                                                       Write(Model.nutritionist.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                        </p>
                    </div>
                </div>
            </div>
            <div class=""card col-12 col-md-6"">
                <div class=""card-wrapper"">
                    <div class=""image-wrapper"">
                        <span class=""mbr-iconfont mobi-mbri-link mobi-mbri""></span>
                    </div>
                    <div class=""text-wrapper"">
                        <h6 class=""card-title mbr-fonts-style mb-1 display-5"">
                            <strong>Linked In</strong>
                        </h6>
");
#nullable restore
#line 108 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                         if (Model.nutritionist.LinkedinLink != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p class=\"mbr-text mbr-fonts-style display-7\">\r\n                                <a href=\"mailto:info@site.com\" class=\"text-primary\">");
#nullable restore
#line 111 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                                                               Write(Model.nutritionist.LinkedinLink);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </p>\r\n");
#nullable restore
#line 113 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
            </div>
            <div class=""card col-12 col-md-6"">
                <div class=""card-wrapper"">
                    <div class=""image-wrapper"">
                        <span class=""mbr-iconfont mobi-mbri-globe mobi-mbri""></span>
                    </div>
                    <div class=""text-wrapper"">
                        <h6 class=""card-title mbr-fonts-style mb-1 display-5"">
                            <strong>Adres</strong>
                        </h6>
                        <p class=""mbr-text mbr-fonts-style display-7"">
                            ");
#nullable restore
#line 127 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                       Write(Model.nutritionist.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </p>
                    </div>
                </div>
            </div>
            <div class=""card col-12 col-md-6"">
                <div class=""card-wrapper"">
                    <div class=""image-wrapper"">
                        <span class=""mbr-iconfont mobi-mbri-bulleted-list mobi-mbri""></span>
                    </div>
                    <div class=""text-wrapper"">
                        <h6 class=""card-title mbr-fonts-style mb-1 display-5"">
                            <strong>Çalışma Saatleri</strong>
                        </h6>
                        <p class=""mbr-text mbr-fonts-style display-7"">
                            ");
#nullable restore
#line 142 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                       Write(Model.nutritionist.WorkingHours);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
#nullable restore
#line 151 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
 if (Model.nutritionist.InstagramLink != null || Model.nutritionist.YoutubeLink != null || Model.nutritionist.FacebookLink != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""share3 cid-smblC300qn"" id=""share3-y"">

        <div class=""container"">
            <div class=""media-container-row"">
                <div class=""col-12"">
                    <h3 class=""mbr-section-title align-center mb-3 mbr-fonts-style display-2"">
                        <strong>Takipte Kal!</strong>
                    </h3>
                    <div class=""social-list align-center"">
");
#nullable restore
#line 162 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                         if (Model.nutritionist.InstagramLink != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"iconfont-wrapper bg-instagram m-2 \" target=\"_blank\"");
            BeginWriteAttribute("href", " href=", 6655, "", 6694, 1);
#nullable restore
#line 164 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
WriteAttributeValue("", 6661, Model.nutritionist.InstagramLink, 6661, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"socicon-instagram socicon\"></span>\r\n                            </a>\r\n");
#nullable restore
#line 167 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 168 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                         if (Model.nutritionist.FacebookLink != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"iconfont-wrapper bg-facebook m-2 \" target=\"_blank\"");
            BeginWriteAttribute("href", " href=", 7025, "", 7063, 1);
#nullable restore
#line 170 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
WriteAttributeValue("", 7031, Model.nutritionist.FacebookLink, 7031, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"socicon-facebook socicon\"></span>\r\n                            </a>\r\n");
#nullable restore
#line 173 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 174 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                         if (Model.nutritionist.YoutubeLink != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"iconfont-wrapper bg-youtube m-1 \" target=\"_blank\"");
            BeginWriteAttribute("href", " href=", 7391, "", 7428, 1);
#nullable restore
#line 176 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
WriteAttributeValue("", 7397, Model.nutritionist.YoutubeLink, 7397, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"socicon-youtube socicon\"></span>\r\n                            </a>\r\n");
#nullable restore
#line 179 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 185 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 187 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
 if (Model.articles != null && Model.articles.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""gallery3 cid-smamM4w0M4"" id=""gallery3-9"">


        <div class=""container-fluid"">
            <div class=""mbr-section-head"">
                <h4 class=""mbr-section-title mbr-fonts-style align-center mb-0 display-2""><strong>Yayımladığı Makaleler</strong></h4>

            </div>

            ");
#nullable restore
#line 198 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
       Write(Html.Partial("~/Views/Shared/ArticleListPartial.cshtml", Model.articles));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 202 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 204 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
 if (userIdSession != -1 && nutritionistIdSession != Model.nutritionist.Id)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""form5 cid-smbjZuFWDN"" id=""form5-q"">


        <div class=""container"" style=""background-color: rgb(240, 240, 240);"">
            <div class=""mbr-section-head  p-4"">
                <h3 class=""mbr-section-title mbr-fonts-style align-center mb-0 display-2"">
                    <strong>Yorumunuz Ekleyin</strong>
                </h3>

            </div>
            <div class=""row justify-content-center mt-4"">
                <div class=""col-lg-8 mx-auto mbr-form"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf7dd39c092cef3d6e2f42c86454f1fcdd88bbb622934", async() => {
                WriteLiteral(@"
                        <p class=""mbr-text mbr-fonts-style align-center mb-4 display-7"">
                            Uygunsuz bir yorumdan dolayı doğacak olan tüm sorumluklar size aittir.
                        </p>
                        <div class=""col-12 form-group"">
                            <textarea name=""commentContent"" id=""commentContent"" placeholder=""Message"" class=""form-control"" rows=""3""></textarea>
                        </div>
                        <div class=""col-auto mbr-section-btn align-center pb-4 submit_btn_show_hide"">
                            <button type=""submit"" class=""btn btn-primary display-4"">Gönder</button>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-nutritionistId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 218 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                                                                                                                                     WriteLiteral(Model.nutritionist.Id.ToString());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["nutritionistId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-nutritionistId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["nutritionistId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 233 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
#nullable restore
#line 238 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
 if (Model.comments != null && Model.comments.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""features9 cid-smbnLOvdds"" id=""features10-13"">
        <!---->


        <div class=""container"">
            <div class=""mbr-section-head"">
                <h3 class=""mbr-section-title mbr-fonts-style mb-0 display-2"">
                    <strong>Yorumlar</strong>
                </h3>

            </div>
            <div class=""row mt-4"">
");
#nullable restore
#line 252 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                 foreach (var comment in Model.comments)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""card col-12"">
                        <div class=""card-wrapper"">
                            <div class=""top-line row"">
                                <div class=""col"">
                                    <h4 class=""card-title mbr-fonts-style display-5""><strong>");
#nullable restore
#line 258 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                                                                        Write(comment.User.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h4>\r\n                                </div>\r\n                                <div class=\"col-auto\">\r\n                                    <i>");
#nullable restore
#line 261 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                  Write(comment.UpdateDate.Date.ToString("dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"bottom-line\">\r\n                                <p class=\"mbr-text mbr-fonts-style display-7\">\r\n                                    ");
#nullable restore
#line 266 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                               Write(comment.CommentContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n");
#nullable restore
#line 269 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                             if (userIdSession == comment.UserId)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\" \" style=\"position: absolute; bottom: 0;right: 0;\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf7dd39c092cef3d6e2f42c86454f1fcdd88bbb630292", async() => {
                WriteLiteral("Yorumu Kaldır");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 272 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                                                                                                 WriteLiteral(comment.Id.ToString());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </div>\r\n");
#nullable restore
#line 276 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 279 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 283 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf7dd39c092cef3d6e2f42c86454f1fcdd88bbb633779", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    $('#commentContent').keyup(function () {

        // If value is not empty
        if ($(this).val().length == 0) {
            // Hide the element
            $('.submit_btn_show_hide').hide();
        } else {
            // Otherwise show it
            $('.submit_btn_show_hide').show();
        }
    }).keyup();

</script>");
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "C:\Users\VodviL\source\repos\Beslenme-Uzmanim\Nutritionist\Nutritionist.Web\Views\Nutritionist\Detail.cshtml"
           

    String ArrayToBase64(byte[] arr)
    {
        var res = Convert.ToBase64String(arr);
        return res;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Nutritionist.Web.Models.ApiModelsCombines.NutritionistContDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
