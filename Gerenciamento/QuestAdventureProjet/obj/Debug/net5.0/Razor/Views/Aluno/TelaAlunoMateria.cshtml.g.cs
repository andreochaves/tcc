#pragma checksum "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "713bb40a5e4ed166628466d520d0fdb55c8f0ab9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Aluno_TelaAlunoMateria), @"mvc.1.0.view", @"/Views/Aluno/TelaAlunoMateria.cshtml")]
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
#line 1 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\_ViewImports.cshtml"
using QuestAdventure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\_ViewImports.cshtml"
using QuestAdventure.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"713bb40a5e4ed166628466d520d0fdb55c8f0ab9", @"/Views/Aluno/TelaAlunoMateria.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bd29956da5019c87d590d8ee6e6b7410927cd13", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Aluno_TelaAlunoMateria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<QuestAdventure.Models.Avaliacao>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString(" Voltar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TelaAluno", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Aluno", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
  
    Layout = "Professor/_LayoutTelaProfessor";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713bb40a5e4ed166628466d520d0fdb55c8f0ab95540", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "713bb40a5e4ed166628466d520d0fdb55c8f0ab95806", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n    <h2>Sua Matéria: ");
#nullable restore
#line 12 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
                Write(QuestAdventure.Controllers.UserManager._materia);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 14 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
     if (Model != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
         foreach (var row in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"form-group\">\r\n                <a class=\"btn  btn-secondary btn-lg btn-block\"");
                BeginWriteAttribute("href", " href=", 494, "", 576, 1);
#nullable restore
#line 19 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
WriteAttributeValue("", 500, Url.Action("SelecionarAvaliacao","Aluno",new{id=row.Id,tent=row.Tentativa}), 500, 76, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 19 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
                                                                                                                                            Write(row.Nome);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n            </div>\r\n");
#nullable restore
#line 21 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
         
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <h4>\r\n        <font color=\"red\">\r\n            ");
#nullable restore
#line 25 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Aluno\TelaAlunoMateria.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </font>\r\n    </h4>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<QuestAdventure.Models.Avaliacao>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
