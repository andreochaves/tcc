#pragma checksum "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2edb4f07852b39b704e69c7a9cb79137317a0568"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProfessorQuestao_EditAlternativa), @"mvc.1.0.view", @"/Views/ProfessorQuestao/EditAlternativa.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2edb4f07852b39b704e69c7a9cb79137317a0568", @"/Views/ProfessorQuestao/EditAlternativa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bd29956da5019c87d590d8ee6e6b7410927cd13", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ProfessorQuestao_EditAlternativa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuestAdventure.Models.Alternativas>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListaQuestao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditarAlternativa", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
  
    Layout = "Professor/_LayoutProfessorTelaQuestao";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Cadastro de Alternativa</h1>\r\n\r\n\r\n<table class=\"table\">\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th>Alternativas </th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n");
#nullable restore
#line 16 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
         if (QuestAdventure.Controllers.UserManager.alternativasEdit != null)
		{
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
             foreach (var row in QuestAdventure.Controllers.UserManager.alternativasEdit)
			{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 21 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
                   Write(row.Alternativa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 22 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
                   Write(row.Correto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>\r\n\t\t\t\t\t\t");
#nullable restore
#line 24 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
                   Write(Html.ActionLink("Edit", "EditAlternativaEdit", new { alternativa = row.Alternativa }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t\t\t\t\t</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 27 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
			}

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
             
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2edb4f07852b39b704e69c7a9cb79137317a05687709", async() => {
                WriteLiteral("\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2edb4f07852b39b704e69c7a9cb79137317a05687969", async() => {
                    WriteLiteral("Atualizar Questão");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\t<h4>\r\n        <font color=\"red\">\r\n        ");
#nullable restore
#line 38 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\ProfessorQuestao\EditAlternativa.cshtml"
   Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </font>\r\n    </h4>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuestAdventure.Models.Alternativas> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591