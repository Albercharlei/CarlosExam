#pragma checksum "C:\Users\Carlos Avalos\source\repos\EXAM\exam\ExamFront\Views\Home\Eliminar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7e2e757adf70541280147205b1d086496ab50b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Eliminar), @"mvc.1.0.view", @"/Views/Home/Eliminar.cshtml")]
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
#line 1 "C:\Users\Carlos Avalos\source\repos\EXAM\exam\ExamFront\Views\_ViewImports.cshtml"
using ExamFront;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Carlos Avalos\source\repos\EXAM\exam\ExamFront\Views\_ViewImports.cshtml"
using ExamFront.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7e2e757adf70541280147205b1d086496ab50b1", @"/Views/Home/Eliminar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a23a7c8a52590ce09b4a042d5cb7786ce606783", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Eliminar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script>
    //array of forms
    let encuestas = [];
    //dropdown element
    let listencuestas = document.getElementById(""dropdownencuestas"");
    let btnDel = document.getElementById(""btnDel"");
    //form description labels
    let formName = document.getElementById(""formName"");
    let formDescription = document.getElementById(""formDescription"");

    const loadForm = () => {
        let listencuestas = document.getElementById(""dropdownencuestas"");
        const formName = document.getElementById(""formName"");
        const formDescription = document.getElementById(""formDescription"");
        //load form
        let selectedForm = encuestas[listencuestas.selectedIndex];
        //set labels of elements
        formName.innerHTML = ""Nombre de la encuesta: "" + selectedForm.nombre;
        formDescription.innerHTML = ""Descripci??n de la encuesta: "" + selectedForm.descripcion;

    }

    const success = result => {
        encuestas = [];
        encuestas = result;
        //flush a");
            WriteLiteral(@"ll options when reloading
        document.getElementById(""dropdownencuestas"").innerHTML = """";
        //loop through all results
        encuestas.forEach(function (encuestaactual) {
            document.getElementById(""dropdownencuestas"").innerHTML += ""<option value=???"" + encuestaactual.id.toString() + ""???>"" + encuestaactual.nombre.toString() + ""</option>"";
        });
        //load first element
        loadForm()
    }

    const ready = () => {
        $.ajax({
            type: 'GET',
            url: '/Home/GetEncuestas',
            data: {},
            cache: false,
            success
        });

    }

    $(document).ready(ready);

    const del = () => {
        let listencuestas = document.getElementById(""dropdownencuestas"");
        let selectedForm = encuestas[listencuestas.selectedIndex];
        $.ajax({
            type: 'POST',
            url: '/Home/DelEncuestas',
            data: {'id' : selectedForm.id},
            cache: false,
            success
  ");
            WriteLiteral(@"      });
    }
    
</script>

<select id=""dropdownencuestas"" onchange=""loadForm();""></select>
<br />
<br />
<div class=row>
        <div class=col>
            <label id=""formName""></label>
        </div>
        <div class=col>
            <label id=""formDescription""></label>
        </div>
</div>
<br />
<br />
<button id=""btnDel"" onclick=""del();"">Eliminar encuesta</button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
