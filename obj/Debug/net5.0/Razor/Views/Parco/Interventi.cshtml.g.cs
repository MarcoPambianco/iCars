#pragma checksum "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f2c4dab34fecaf600765e812bd5aeb68b4c1c96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Parco_Interventi), @"mvc.1.0.view", @"/Views/Parco/Interventi.cshtml")]
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
#line 1 "C:\PAM_SW\iCars\Views\_ViewImports.cshtml"
using iCars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\PAM_SW\iCars\Views\_ViewImports.cshtml"
using iCars.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f2c4dab34fecaf600765e812bd5aeb68b4c1c96", @"/Views/Parco/Interventi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"706f2e95ec3461253e033013fcfdf54cd48df5cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Parco_Interventi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<section class=\"dettagli-macchina\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-9\">\r\n            <h1>");
#nullable restore
#line 6 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
           Write(Model.strMarca);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 6 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                           Write(Model.strModello);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 6 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                              Write(Model.strTarga);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h1>
        </div>
        <div class=""col-md-3 d-flex align-items-end"">
                <a href=""#"" class=""btn btn-warning btn-lg btn-block add-intervento"">Nuovo intervento</a>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-9"">
            <p style=""text-align: justify;"">
");
#nullable restore
#line 15 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                 foreach(InterventiViewModel intervento in @Model.lsInterventi){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-md-3\">");
#nullable restore
#line 17 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                     Write(intervento.tipoIntervento.strDescrizione);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-2\">");
#nullable restore
#line 18 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                     Write(intervento.DataToString(intervento.dataIntervento));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-2\">Km ");
#nullable restore
#line 19 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                        Write(intervento.kilometriMacchina);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-2\">Durata ");
#nullable restore
#line 20 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                            Write(intervento.tipoIntervento.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"col-md-3\">Prossimo controllo ");
#nullable restore
#line 21 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                                        Write(intervento.GetProssimoControllo());

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n                <hr>\r\n");
#nullable restore
#line 24 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
            }                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </p>\r\n        </div>\r\n        <div class=\"col-md-3 d-flex align-items-end \">\r\n            <aside class=\"MyAside\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1315, "\"", 1340, 1);
#nullable restore
#line 29 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
WriteAttributeValue("", 1321, Model.strImagePath, 1321, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"80\">\r\n                <div>KM: ");
#nullable restore
#line 30 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                    Write(Model.Kilometri);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div>Alimentazione: ");
#nullable restore
#line 31 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                               Write(Model.motorizzazione.alimentazione);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div>Potenza: ");
#nullable restore
#line 32 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                         Write(Model.motorizzazione.cavalli);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 32 "C:\PAM_SW\iCars\Views\Parco\Interventi.cshtml"
                                                        Write(Model.motorizzazione.kw);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</div>\r\n            </aside>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
