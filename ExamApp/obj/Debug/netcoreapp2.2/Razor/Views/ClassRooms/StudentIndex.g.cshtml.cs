#pragma checksum "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30cc64821799118f4179dbc49373d82bf498e241"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ClassRooms_StudentIndex), @"mvc.1.0.view", @"/Views/ClassRooms/StudentIndex.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ClassRooms/StudentIndex.cshtml", typeof(AspNetCore.Views_ClassRooms_StudentIndex))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30cc64821799118f4179dbc49373d82bf498e241", @"/Views/ClassRooms/StudentIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cc381882eeb32e8d2e90d7f36eb84b506bb0834", @"/Views/_ViewImports.cshtml")]
    public class Views_ClassRooms_StudentIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ExamApp.Models.ClassRoomStudent>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Exams", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/vendor/datatable/js/jquery.dataTables.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/vendor/datatable/js/dataTables.bootstrap4.min.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
  
    ViewData["Title"] = "ClassRooms";

#line default
#line hidden
            BeginContext(99, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Css", async() => {
                BeginContext(115, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 7 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
      await Html.RenderPartialAsync("_DataTableCssPartial");

#line default
#line hidden
            }
            );
            BeginContext(183, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Sole", async() => {
                BeginContext(200, 175, true);
                WriteLiteral("\r\n    <style>\r\n\r\n\r\n        .table tr th:last-child {\r\n            width: 50px;\r\n        }\r\n\r\n        .table tr th {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(378, 1468, true);
            WriteLiteral(@"
<div class=""container-fluid mt-4"">
    <div class=""card animated fadeIn overflow-hidden"">
        <div class=""card-header p-3"">
            <div class=""row align-items-center"">
                <div class=""col"">
                    <h3 class=""mb-0 skewed skewed-yellow text-dark d-inline-block text-uppercase ls-1"">ClassRooms</h3>
                </div>
             
            </div>
        </div>
        <div class=""card-body px-0 pb-2"">
            <div class="""">

                <table class=""table align-items-center  table-striped table-bordered"" id=""datatable-basic"">
                    <thead class=""thead-light"">
                        <tr>

                            <th>
                                Course Name
                            </th>
                                <th>
                                Course Code
                            </th>

                            <th>
                                Section Name
                            </th>");
            WriteLiteral(@"
                            <th>
                                Teacher Name
                            </th>
                            <th>
                                Status
                            </th>
                            <th class=""text-center"">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 63 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(1927, 110, true);
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2038, 26, false);
#line 68 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                               Write(item.ClassRoom.Course.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2064, 116, true);
            WriteLiteral("\r\n                                </td>\r\n                                 <td>\r\n                                    ");
            EndContext();
            BeginContext(2181, 26, false);
#line 71 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                               Write(item.ClassRoom.Course.Code);

#line default
#line hidden
            EndContext();
            BeginContext(2207, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2325, 31, false);
#line 75 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                               Write(item.ClassRoom.Section.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(2356, 117, true);
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2474, 27, false);
#line 79 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                               Write(item.ClassRoom.Teacher.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2501, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2617, 21, false);
#line 82 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                               Write(item.ClassRoom.Status);

#line default
#line hidden
            EndContext();
            BeginContext(2638, 236, true);
            WriteLiteral("\r\n                                </td>\r\n                               \r\n                                <td class=\"text-center\">\r\n                                    <div class=\"btn-group\">\r\n\r\n                                         ");
            EndContext();
            BeginContext(2874, 128, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30cc64821799118f4179dbc49373d82bf498e24110922", async() => {
                BeginContext(2993, 5, true);
                WriteLiteral("Exams");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-classRoomId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 88 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                                                                                                                                WriteLiteral(item.ClassRoom.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classRoomId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-classRoomId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["classRoomId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3002, 128, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 96 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
                        }

#line default
#line hidden
            BeginContext(3157, 122, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3297, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3303, 119, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30cc64821799118f4179dbc49373d82bf498e24114344", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#line 109 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3422, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(3428, 123, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30cc64821799118f4179dbc49373d82bf498e24116486", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
#line 110 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
                BeginContext(3551, 56, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n    </script>\r\n");
                EndContext();
#line 114 "D:\ExamApp\ExamApp\Views\ClassRooms\StudentIndex.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
            BeginContext(3678, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ExamApp.Models.ClassRoomStudent>> Html { get; private set; }
    }
}
#pragma warning restore 1591
