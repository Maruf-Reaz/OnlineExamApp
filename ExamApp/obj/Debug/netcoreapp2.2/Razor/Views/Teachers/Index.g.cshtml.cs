#pragma checksum "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "560c57d511a7a22eececacd990e71e8c1404f6aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teachers_Index), @"mvc.1.0.view", @"/Views/Teachers/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Teachers/Index.cshtml", typeof(AspNetCore.Views_Teachers_Index))]
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
#line 1 "D:\ExamApp\ExamApp\Views\_ViewImports.cshtml"
using ExamApp;

#line default
#line hidden
#line 2 "D:\ExamApp\ExamApp\Views\_ViewImports.cshtml"
using ExamApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"560c57d511a7a22eececacd990e71e8c1404f6aa", @"/Views/Teachers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cc381882eeb32e8d2e90d7f36eb84b506bb0834", @"/Views/_ViewImports.cshtml")]
    public class Views_Teachers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ExamApp.Models.Teacher>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-greenyellow btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/vendor/datatable/js/jquery.dataTables.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/vendor/datatable/js/dataTables.bootstrap4.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
  
    ViewData["Title"] = "Teacher";

#line default
#line hidden
            BeginContext(87, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Css", async() => {
                BeginContext(103, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 7 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
      await Html.RenderPartialAsync("_DataTableCssPartial");

#line default
#line hidden
            }
            );
            BeginContext(171, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Sole", async() => {
                BeginContext(188, 169, true);
                WriteLiteral("\r\n    <style>\r\n\r\n\r\n        .table tr th:last-child {\r\n            width: 50px;\r\n        }\r\n\r\n        .table tr th {\r\n            text-align: center;\r\n        }\r\n        ");
                EndContext();
                BeginContext(358, 340, true);
                WriteLiteral(@"@media screen and (max-width: 991px) {
            .before-table-responsive .col-sm-12 {
                padding: 0;
                margin-left: 1rem;
                margin-right: 1rem
            }
            /*.buttons-pdf,
            .buttons-excel {
                display: none;
            }*/
        }
    </style>
");
                EndContext();
            }
            );
            BeginContext(701, 425, true);
            WriteLiteral(@"
<div class=""container-fluid mt-4"">
    <div class=""card animated fadeIn overflow-hidden"">
        <div class=""card-header p-3"">
            <div class=""row align-items-center"">
                <div class=""col"">
                    <h3 class=""mb-0 skewed skewed-yellow text-dark d-inline-block text-uppercase ls-1"">Teacher</h3>
                </div>
                <div class=""col text-right"">
                    ");
            EndContext();
            BeginContext(1126, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560c57d511a7a22eececacd990e71e8c1404f6aa7703", async() => {
                BeginContext(1172, 3, true);
                WriteLiteral("New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1179, 1227, true);
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class=""card-body px-0 pb-2"">
            <div class="""" id=""table_wrapper"">

                <table class=""table align-items-center  table-striped table-bordered"" id=""datatable-basic1"">
                    <thead class=""thead-light"">
                        <tr>

                            <th>
                                Name
                            </th>
                            <th>
                                Department
                            </th>
                            <th>
                                Designation
                            </th>
                            <th>
                                Id No
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Phone No
                            </th>

                ");
            WriteLiteral("            <th class=\"text-center\">\r\n                                Action\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
            EndContext();
#line 79 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(2487, 110, true);
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2598, 9, false);
#line 84 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                               Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2607, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2725, 20, false);
#line 88 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                               Write(item.Department.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2745, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2861, 21, false);
#line 91 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                               Write(item.Designation.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2882, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3000, 9, false);
#line 95 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                               Write(item.IdNo);

#line default
#line hidden
            EndContext();
            BeginContext(3009, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3125, 10, false);
#line 98 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                               Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(3135, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(3253, 12, false);
#line 102 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                               Write(item.PhoneNo);

#line default
#line hidden
            EndContext();
            BeginContext(3265, 206, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td class=\"text-center\">\r\n                                    <div class=\"btn-group\">\r\n\r\n                                        ");
            EndContext();
            BeginContext(3471, 88, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560c57d511a7a22eececacd990e71e8c1404f6aa13573", async() => {
                BeginContext(3551, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 109 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                                                                                                  WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3559, 120, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 113 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(3706, 122, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3846, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3852, 119, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560c57d511a7a22eececacd990e71e8c1404f6aa16680", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#line 126 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3971, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3977, 123, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560c57d511a7a22eececacd990e71e8c1404f6aa18813", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#line 127 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4100, 389, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            var table = $('#datatable-basic1').DataTable({
                lengthChange: false,
                buttons: ['copy', 'excel', 'pdf', 'colvis']
            });

            table.buttons().container()
                .appendTo('#table_wrapper .col-md-6:eq(0)');
        });
    </script>
");
                EndContext();
#line 139 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
      await Html.RenderPartialAsync("_DataTablesJsPartial");

#line default
#line hidden
                BeginContext(4552, 4, true);
                WriteLiteral("    ");
                EndContext();
#line 140 "D:\ExamApp\ExamApp\Views\Teachers\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ExamApp.Models.Teacher>> Html { get; private set; }
    }
}
#pragma warning restore 1591