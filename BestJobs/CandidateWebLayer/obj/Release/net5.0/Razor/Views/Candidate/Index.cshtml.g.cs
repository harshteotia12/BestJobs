#pragma checksum "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ddd1c77820c4b5af2cbd02d37921deb51ef4115"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candidate_Index), @"mvc.1.0.view", @"/Views/Candidate/Index.cshtml")]
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
#line 1 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\_ViewImports.cshtml"
using CandidateWebLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\_ViewImports.cshtml"
using CandidateWebLayer.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ddd1c77820c4b5af2cbd02d37921deb51ef4115", @"/Views/Candidate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"833d6e6f81aa15e144cd8049ac99c7a53a2c5392", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Candidate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CandidateWebLayer.Models.AllJobsModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Candidate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "JobDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
 if(ViewBag.IsSelected == false)
{

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
 foreach (var item in Model) 
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section style=""background-color: white;"">
    <div class=""row justify-content-center mb-3"">
      <div class=""col-md-12 col-xl-10"">
        <div class=""card shadow-0 border rounded-3"">
          <div class=""card-body"">
            <div class=""row"">
              <div class=""col-md-12 col-lg-3 col-xl-3 mb-4 mb-lg-0"">
                <div class=""bg-image hover-zoom ripple rounded ripple-surface"">
");
#nullable restore
#line 18 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
                 if (@item.OrgPhoto != null)
			    {
				    string imageBase64 = Convert.ToBase64String(@item.OrgPhoto);
				    string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t    <img");
            BeginWriteAttribute("src", " src=\"", 802, "\"", 817, 1);
#nullable restore
#line 22 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
WriteAttributeValue("", 808, imageSrc, 808, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100\" height=\"100\" />\r\n");
#nullable restore
#line 23 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
			    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                  <a href=""#!"">
                    <div class=""hover-overlay"">
                      <div class=""mask"" style=""background-color: rgba(253, 253, 253, 0.15);""></div>
                    </div>
                  </a>
                </div>
              </div>
              <div class=""col-md-6 col-lg-6 col-xl-6"">
                <h5>");
#nullable restore
#line 32 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Orgname));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                <div class=""d-flex flex-row"">
                  <div class=""text-danger mb-1 me-2"">
                    <i class=""fa fa-star""></i>
                    <i class=""fa fa-star""></i>
                    <i class=""fa fa-star""></i>
                    <i class=""fa fa-star""></i>
                  </div>
                  <span>Annual CTC : ");
#nullable restore
#line 40 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
                                Write(Html.DisplayFor(modelItem => item.JobsPackage));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"mb-2 text-muted small\">\r\n                  <span>");
#nullable restore
#line 43 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.JobsSkill));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <p class=\"text-truncate mb-4 mb-md-0\">\r\n                  ");
#nullable restore
#line 46 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
             Write(Html.DisplayFor(modelItem => item.JobsDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n              </div>\r\n                <div class=\"d-flex flex-column mt-4\">\r\n                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ddd1c77820c4b5af2cbd02d37921deb51ef41158903", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 50 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
                                                                                                        WriteLiteral(item.JobsId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n              </div>\r\n            </div>\r\n          </div>\r\n        </div>\r\n      </div>\r\n</section>\r\n");
#nullable restore
#line 58 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
 
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Congo!!! you have been selected for the job => ");
#nullable restore
#line 62 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
                                                  Write(ViewBag.JobName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ddd1c77820c4b5af2cbd02d37921deb51ef411512417", async() => {
                WriteLiteral("View Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
                                    WriteLiteral(ViewBag.jobsId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 64 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CandidateWebLayer.Models.AllJobsModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
