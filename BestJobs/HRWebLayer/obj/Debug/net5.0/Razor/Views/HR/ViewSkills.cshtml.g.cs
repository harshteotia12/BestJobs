#pragma checksum "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4669a6fa191629d6752eae7f99e5b88477363465"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HR_ViewSkills), @"mvc.1.0.view", @"/Views/HR/ViewSkills.cshtml")]
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
#line 1 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\_ViewImports.cshtml"
using HRWebLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\_ViewImports.cshtml"
using HRWebLayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4669a6fa191629d6752eae7f99e5b88477363465", @"/Views/HR/ViewSkills.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c432684fc31910b4a52b5c51de17c9aec7587f5", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_HR_ViewSkills : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HRWebLayer.Models.SkillsModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
  
    ViewData["Title"] = "ViewSkills";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n");
#nullable restore
#line 8 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
           foreach(var list in Model)
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-6\">\r\n                   <div class=\"card mb-4 mb-md-0\">\r\n                   <div class=\"card-body\">\r\n                   <p class=\"mt-4 mb-1\" style=\"font-size: .77rem;\">");
#nullable restore
#line 14 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
                                                              Write(list.SkillName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n");
#nullable restore
#line 15 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
                        if (list.Matched)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>Matched</p>\r\n");
#nullable restore
#line 18 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                   <div class=\"progress rounded\" style=\"height: 5px;\">\r\n                   <div class=\"progress-bar\" role=\"progressbar\"");
            BeginWriteAttribute("style", " style=\"", 694, "\"", 732, 3);
            WriteAttributeValue("", 702, "width:", 702, 6, true);
#nullable restore
#line 20 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
WriteAttributeValue(" ", 708, list.SkillProficiency, 709, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 731, "%", 731, 1, true);
            EndWriteAttribute();
            WriteLiteral(" aria-valuenow=\"72\"aria-valuemin=\"0\" aria-valuemax=\"100\"></div>\r\n                        \r\n                    </div>\r\n                   </div>\r\n                   </div>\r\n                   </div>\r\n");
#nullable restore
#line 26 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr>\r\n        <hr>\r\n          </div>\r\n          <p>Observations : HaveSkills/Reqd Skills => ");
#nullable restore
#line 30 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
                                                 Write(ViewBag.GotSkills);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 30 "C:\Users\harsh\OneDrive\Desktop\BestJobs\BestJobs\HRWebLayer\Views\HR\ViewSkills.cshtml"
                                                                    Write(ViewBag.TotalSkills);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HRWebLayer.Models.SkillsModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
