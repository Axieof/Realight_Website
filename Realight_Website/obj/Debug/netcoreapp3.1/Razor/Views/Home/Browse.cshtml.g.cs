#pragma checksum "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44b2ee5885e470b5d6678cbfb21860ec4b3e3dc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Browse), @"mvc.1.0.view", @"/Views/Home/Browse.cshtml")]
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
#line 1 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\_ViewImports.cshtml"
using Realight_Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\_ViewImports.cshtml"
using Realight_Website.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44b2ee5885e470b5d6678cbfb21860ec4b3e3dc8", @"/Views/Home/Browse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a167de90824dbe830034a11c347f11a9c601c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Browse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Realight_Website.Models.Room>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("person"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/whiteperson.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/link.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
  
    ViewData["Title"] = "Browse";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-1\"></div>\r\n    <div class=\"col-10 browse-filters\">Sort by:</div>\r\n    <div class=\"col-1\"></div>\r\n</div>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-1\"></div>\r\n    <div class=\"browse-container col-10\">\r\n");
#nullable restore
#line 17 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"map-panel\"");
            BeginWriteAttribute("href", " href=\"", 420, "\"", 427, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"map-header\">\r\n                    <div class=\"map-header-info\">\r\n                        <div id=\"title\">");
#nullable restore
#line 22 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        ");
#nullable restore
#line 23 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ownername));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"player-count\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "44b2ee5885e470b5d6678cbfb21860ec4b3e3dc86656", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <span>");
#nullable restore
#line 26 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
                         Write(Html.DisplayFor(modelItem => item.playerCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"map-info\">\r\n                    <div class=\"tag-container\">\r\n");
#nullable restore
#line 32 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
                         for (int i = 0; i < item.interestTag.Count(); i++)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"tag\">");
#nullable restore
#line 34 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
                                        Write(Html.DisplayFor(modelItem => item.interestTag[i]));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 35 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"link\"><a");
            BeginWriteAttribute("href", " href=\"", 1364, "\"", 1371, 0);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "44b2ee5885e470b5d6678cbfb21860ec4b3e3dc89438", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a></div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 40 "D:\Polytechnic Stuff\Semster 2.2\P2\Realight\Realight_Project\Realight_Website\Views\Home\Browse.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n    <div class=\"col-1\"></div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Realight_Website.Models.Room>> Html { get; private set; }
    }
}
#pragma warning restore 1591
