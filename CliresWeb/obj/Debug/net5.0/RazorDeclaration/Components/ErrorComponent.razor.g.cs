// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CliresWeb.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using AKSoftware.Localization.MultiLanguages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using AKSoftware.Localization.MultiLanguages.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using ApplicationCore.Repositories.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using ApplicationCore.Services.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/error/{errorCode:int}")]
    public partial class ErrorComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\C_WORKING\Clires_v3.0\CliresRDMS\CliresWeb\Components\ErrorComponent.razor"
       
    [Parameter]
    public string errorCode { get; set; } = "500";
    [Parameter]
    public string errorMessage { get; set; } = "Something went really wrong. Please contact administrator";
    protected override void OnInitialized()
    {
        languageContainer.InitLocalizedComponent(this);
        switch(errorCode)
        {
            case "404":
                errorMessage = languageContainer.Keys["error_page:error_404_msg"];
                break;
            case "401":
                errorMessage = languageContainer.Keys["error_page:unauthorized"];
                break;
            default:
                errorMessage = languageContainer.Keys["error_page:system_error_msg"];
                break;     
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILanguageContainerService languageContainer { get; set; }
    }
}
#pragma warning restore 1591
