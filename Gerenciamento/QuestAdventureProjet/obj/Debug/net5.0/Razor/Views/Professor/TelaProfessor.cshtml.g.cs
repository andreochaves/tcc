#pragma checksum "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be1834977b562ee4a045456d7b3a22c64fc1a8c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Professor_TelaProfessor), @"mvc.1.0.view", @"/Views/Professor/TelaProfessor.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be1834977b562ee4a045456d7b3a22c64fc1a8c2", @"/Views/Professor/TelaProfessor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bd29956da5019c87d590d8ee6e6b7410927cd13", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Professor_TelaProfessor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuestAdventure.Models.Professor>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml"
  
	Layout = "Professor/_LayoutTelaProfessor";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Bem-Vindo ");
#nullable restore
#line 6 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml"
         Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\t<h2>Suas Matérias</h2>\r\n\r\n");
#nullable restore
#line 10 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml"
 foreach (var row in QuestAdventure.Controllers.UserManager.MateriaProfessor.OrderBy(item=>item.Materia))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"form-group\">\r\n\t\t<a class=\"btn  btn-info btn-lg btn-block\"");
            BeginWriteAttribute("href", " href=", 335, "", 413, 1);
#nullable restore
#line 13 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml"
WriteAttributeValue("", 341, Url.Action("Selecionar","Professor",new{materia=row.Materia,id=row.Id}), 341, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 13 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml"
                                                                                                                           Write(row.Materia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t</div>\r\n");
#nullable restore
#line 15 "C:\Users\andre\OneDrive\Área de Trabalho\tcc back\questadventure\QuestAdventure\QuestAdventure\Views\Professor\TelaProfessor.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuestAdventure.Models.Professor> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
