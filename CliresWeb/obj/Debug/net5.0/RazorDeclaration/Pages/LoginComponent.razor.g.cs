// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CliresWeb.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Controls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using ApplicationCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using ApplicationCore.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Models.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Entities.CliresSystem;

#line default
#line hidden
#nullable disable
    public partial class LoginComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 96 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\LoginComponent.razor"
       
	AlertComponent alertComponent;

	UserLoginModel userViewModel;

	protected override void OnInitialized()
	{
		userViewModel = new UserLoginModel();
	}

	async Task Login()
	{
		var token = await AuthenticationUseCases.LoginAsync(userViewModel.UserName, userViewModel.Password);
		if (string.IsNullOrWhiteSpace(token))
		{
			alertComponent.ErrorMessage = "Login Failled.";
			alertComponent.Show();
		}
		else
			NavigationManager.NavigateTo("/", true);
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationService AuthenticationUseCases { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
