#pragma checksum "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6db87247f93eb091b7a9b61d4c96353bd34ebb2b"
// <auto-generated/>
#pragma warning disable 1591
namespace CliresWeb.Pages.Admin
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
#line 16 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Pages.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using CliresWeb.Pages.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using ApplicationCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using ApplicationCore.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Models.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\_Imports.razor"
using Infrastructure.Entities.CliresSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/permissions")]
    public partial class Permissions : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<section class=""content-header""><div class=""container-fluid""><div class=""row mb-2""><div class=""col-sm-6""><h1>Permission</h1></div>
                <div class=""col-sm-6""><ol class=""breadcrumb float-sm-right""><li class=""breadcrumb-item""><a href=""#"">Adminnistrator</a></li>
                        <li class=""breadcrumb-item active"">Permission</li></ol></div></div></div></section>

    
    ");
            __builder.OpenElement(1, "section");
            __builder.AddAttribute(2, "class", "content");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container-fluid");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "row");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "col-12");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "card");
            __builder.AddMarkupContent(11, "<div class=\"card-header\"><h3 class=\"card-title\">DataTable with minimal features & hover style</h3></div>\r\n                        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "card-body");
#nullable restore
#line 33 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                             if (permissions != null)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(14, "table");
            __builder.AddAttribute(15, "class", "table table-bordered table-hover");
            __builder.AddMarkupContent(16, @"<thead><tr><th>Permission</th>
                                        <th>Status</th>
                                        <th>Created By</th>
                                        <th>Created Date</th></tr></thead>
                                ");
            __builder.OpenElement(17, "tbody");
#nullable restore
#line 45 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                                     foreach (var perm in permissions)
                                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(18, "tr");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 49 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                                             perm.Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                                        ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 52 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                                             perm.Status

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                                        ");
            __builder.OpenElement(25, "td");
            __builder.AddContent(26, 
#nullable restore
#line 55 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                                             perm.CreatedBy

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                                        ");
            __builder.OpenElement(28, "td");
            __builder.AddContent(29, 
#nullable restore
#line 58 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                                              perm.CreatedDate.ToString("yyyy-MM-dd")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 61 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"

                                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 65 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 78 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Pages\Admin\Permissions.razor"
           

        IEnumerable<TblPermission> permissions;
        string searchFilter;

        protected override async Task OnParametersSetAsync()
        {
            permissions = await PermissionService.ViewPermissionAsync();
        }

        //private void AddPermission()
        //{
        //    NavigationManager.NavigateTo($"/permissions/addpermission");
        //}

    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPermissionService PermissionService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591