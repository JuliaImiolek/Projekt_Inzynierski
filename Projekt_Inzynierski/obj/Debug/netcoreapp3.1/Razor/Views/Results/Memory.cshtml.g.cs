#pragma checksum "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e67956f967bfa806439e6a2a15cede999f15a63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Results_Memory), @"mvc.1.0.view", @"/Views/Results/Memory.cshtml")]
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
#line 1 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\_ViewImports.cshtml"
using Projekt_Inzynierski;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\_ViewImports.cshtml"
using Projekt_Inzynierski.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e67956f967bfa806439e6a2a15cede999f15a63", @"/Views/Results/Memory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"808bffd9bf6e7026011dbb91d893562187dcff91", @"/Views/_ViewImports.cshtml")]
    public class Views_Results_Memory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MemoryModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
  
    ViewData["Title"] = "Memory";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1> Results for memory</h1>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Position
            </th>
            <th>
                Number of click
            </th>
            <th>
                Time [s]
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 26 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
          
            var a = 1;
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 30 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
         foreach (var item in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
           Write(a);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumOfClick));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
           Write(Html.DisplayFor(modelItem => item.GameTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\Julia\source\repos\Projekt_Inzynierski\Projekt_Inzynierski\Views\Results\Memory.cshtml"
            a++;

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MemoryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591