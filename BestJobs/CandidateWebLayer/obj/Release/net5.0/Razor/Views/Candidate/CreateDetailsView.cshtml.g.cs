#pragma checksum "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bf5e040efbc7a51e7c5e558bc180f64f6a655a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Candidate_CreateDetailsView), @"mvc.1.0.view", @"/Views/Candidate/CreateDetailsView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bf5e040efbc7a51e7c5e558bc180f64f6a655a9", @"/Views/Candidate/CreateDetailsView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"833d6e6f81aa15e144cd8049ac99c7a53a2c5392", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Candidate_CreateDetailsView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CandidateWebLayer.Models.CandidateDetailsModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
  
    ViewData["Title"] = "CreateDetailsView";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
body {
	background-color:lightgray;
}
</style>

<section style=""background-color:lightgray;"">

    <div class=""row"">
      <div class=""col-lg-4"">
        <div class=""card mb-4"">
          <div class=""card-body text-center"">
            <img src=""https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp"" alt=""avatar""
              class=""rounded-circle img-fluid"" style=""width: 150px;"">
            <h5 class=""my-3""> 
            ");
#nullable restore
#line 21 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
            <p class=""text-muted mb-1"">Full Stack Developer</p>
          </div>
        </div>
        <div class=""card mb-4 mb-lg-0"">
          <div class=""card-body p-0"">
            <ul class=""list-group list-group-flush rounded-3"">
              <li class=""list-group-item d-flex justify-content-between align-items-center p-3"">
                <i class=""fas fa-globe fa-lg text-warning""></i>
                <p class=""mb-0"">https://");
#nullable restore
#line 30 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                   Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"_site.com</p>
              </li>
              <li class=""list-group-item d-flex justify-content-between align-items-center p-3"">
                <i class=""fab fa-github fa-lg"" style=""color: #333333;""></i>
                <p class=""mb-0"">LinkedIn</p>
              </li>
              <li class=""list-group-item d-flex justify-content-between align-items-center p-3"">
                <i class=""fab fa-instagram fa-lg"" style=""color: #ac2bac;""></i>
                <p class=""mb-0"">GitHub</p>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div class=""col-lg-8"">
        <div class=""card mb-4"">
          <div class=""card-body"">
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">First Name</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0""> ");
#nullable restore
#line 52 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Last Name</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0"">");
#nullable restore
#line 61 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Email</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0"">");
#nullable restore
#line 70 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Phone</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0"">");
#nullable restore
#line 79 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Date Of Birth</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0"">");
#nullable restore
#line 88 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      Write(Html.DisplayFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Mobile</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0"">");
#nullable restore
#line 97 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Address</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0""> ");
#nullable restore
#line 106 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                       Write(Html.DisplayFor(model => model.AddLine));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 106 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                                                                 Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
              </div>
            </div>
            <hr>
            <div class=""row"">
              <div class=""col-sm-3"">
                <p class=""mb-0"">Country</p>
              </div>
              <div class=""col-sm-9"">
                <p class=""text-muted mb-0"">");
#nullable restore
#line 115 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n              </div>\r\n            </div>\r\n            <hr>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0bf5e040efbc7a51e7c5e558bc180f64f6a655a911714", async() => {
                WriteLiteral("Edit Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 123 "C:\Users\harteoti\BestJobsProject\PSI-2022-Apr-DotNet-Eng-Batch\BestJobs\CandidateWebLayer\Views\Candidate\CreateDetailsView.cshtml"
                                      WriteLiteral(Model.CandidateDetailsId);

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
            WriteLiteral("\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CandidateWebLayer.Models.CandidateDetailsModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
