#pragma checksum "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14c99992aa506416487fda191e4a6723309254d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
#line 1 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\_ViewImports.cshtml"
using MyTutorial1.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\_ViewImports.cshtml"
using MyTutorial1.Models;

#line default
#line hidden
#line 3 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14c99992aa506416487fda191e4a6723309254d1", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"668bd4a0d9dd46f17bd3120d4091272b57b57b40", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\Shared\Error.cshtml"
 if (ViewBag.ErrorTitle == null) {

#line default
#line hidden
            BeginContext(36, 189, true);
            WriteLiteral("<h3>\r\n    An Error occured while processing your request. The support\r\n    team is notified and we are working on the fix\r\n</h3>\r\n<h5>Please contact us on pragim@pragimtech.com</h5>\r\n<hr />");
            EndContext();
#line 7 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\Shared\Error.cshtml"
      }
else
{

#line default
#line hidden
            BeginContext(237, 24, true);
            WriteLiteral("<h1 class=\"text-danger\">");
            EndContext();
            BeginContext(262, 18, false);
#line 10 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\Shared\Error.cshtml"
                   Write(ViewBag.ErrorTitle);

#line default
#line hidden
            EndContext();
            BeginContext(280, 31, true);
            WriteLiteral("</h1>\r\n<h6 class=\"text-danger\">");
            EndContext();
            BeginContext(312, 20, false);
#line 11 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\Shared\Error.cshtml"
                   Write(ViewBag.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(332, 7, true);
            WriteLiteral("</h6>\r\n");
            EndContext();
#line 12 "C:\Users\ameoo\source\repos\MyTutorial1\MyTutorial1\Views\Shared\Error.cshtml"
}

#line default
#line hidden
            BeginContext(801, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591