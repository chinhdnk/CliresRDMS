#pragma checksum "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bfc09107cd4da51524d810f777748b0c873441fc"
// <auto-generated/>
#pragma warning disable 1591
namespace CliresWeb.Shared
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
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "aside");
                __builder2.AddAttribute(3, "class", "main-sidebar sidebar-dark-primary elevation-4");
                __builder2.AddAttribute(4, "b-saptvulhc8");
                __builder2.AddMarkupContent(5, @"<a href=""index3.html"" class=""brand-link"" b-saptvulhc8><img src=""dist/img/logo.png"" alt=""Clires Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"" b-saptvulhc8>
                <span class=""brand-text font-weight-light"" style=""font-size: 24px;"" b-saptvulhc8>Clires EDC</span></a>

            
            ");
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "sidebar");
                __builder2.AddAttribute(8, "b-saptvulhc8");
                __builder2.AddMarkupContent(9, "<div class=\"user-panel mt-3 pb-3 mb-3 d-flex\" b-saptvulhc8><div class=\"info\" b-saptvulhc8><a href=\"#\" class=\"d-block\" style=\"font-size: 20px;\" b-saptvulhc8>ADMIN PAGE</a></div></div>\r\n                \r\n                ");
                __builder2.OpenElement(10, "nav");
                __builder2.AddAttribute(11, "class", "mt-2");
                __builder2.AddAttribute(12, "b-saptvulhc8");
                __builder2.OpenElement(13, "ul");
                __builder2.AddAttribute(14, "class", "nav nav-pills nav-sidebar flex-column");
                __builder2.AddAttribute(15, "data-widget", "treeview");
                __builder2.AddAttribute(16, "role", "menu");
                __builder2.AddAttribute(17, "data-accordion", "false");
                __builder2.AddAttribute(18, "b-saptvulhc8");
                __builder2.OpenElement(19, "li");
                __builder2.AddAttribute(20, "class", "nav-item has-treeview menu-open");
                __builder2.AddAttribute(21, "b-saptvulhc8");
                __builder2.AddMarkupContent(22, @"<a href=""/home"" class=""nav-link"" b-saptvulhc8><i class=""nav-icon fas fa-users-cog"" b-saptvulhc8></i>
                                <p b-saptvulhc8>
                                    Administration
                                    <i class=""right fas fa-angle-left"" b-saptvulhc8></i></p></a>
                            ");
                __builder2.OpenElement(23, "ul");
                __builder2.AddAttribute(24, "class", "nav nav-treeview");
                __builder2.AddAttribute(25, "b-saptvulhc8");
                __builder2.AddMarkupContent(26, @"<li class=""nav-item pad20"" b-saptvulhc8><a href=""pages/charts/chartjs.html"" class=""nav-link"" b-saptvulhc8><i class=""fas fa-users nav-icon"" b-saptvulhc8></i>
                                        <p b-saptvulhc8>User</p></a></li>
                                ");
                __builder2.AddMarkupContent(27, @"<li class=""nav-item pad20"" b-saptvulhc8><a href=""pages/charts/flot.html"" class=""nav-link"" b-saptvulhc8><i class=""fas fa-user-tag nav-icon"" b-saptvulhc8></i>
                                        <p b-saptvulhc8>Group</p></a></li>
                                ");
                __builder2.OpenElement(28, "li");
                __builder2.AddAttribute(29, "class", "nav-item pad20");
                __builder2.AddAttribute(30, "b-saptvulhc8");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(31);
                __builder2.AddAttribute(32, "href", 
#nullable restore
#line 48 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Shared\NavMenu.razor"
                                                     $"/admin/permissions"

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(33, "class", "nav-link");
                __builder2.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(35, "<i class=\"far fa-circle nav-icon\" b-saptvulhc8></i>\r\n                                        ");
                    __builder3.AddMarkupContent(36, "<p b-saptvulhc8>Permission</p>");
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n                        ");
                __builder2.AddMarkupContent(38, "<li class=\"nav-item has-treeview\" b-saptvulhc8><a href=\"#\" class=\"nav-link\" b-saptvulhc8><i class=\"nav-icon fas fa-cogs\" b-saptvulhc8></i>\r\n                                <p b-saptvulhc8>\r\n                                    System Configuration\r\n                                    <i class=\"fas fa-angle-left right\" b-saptvulhc8></i></p></a>\r\n                            <ul class=\"nav nav-treeview\" b-saptvulhc8><li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/UI/general.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-cog nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>System Parameter</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/UI/icons.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-envelope-open-text nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Mailing & SMS</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/UI/buttons.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-language nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Languages</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/UI/sliders.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-address-book nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Contact Information </p></a></li></ul></li>\r\n                        ");
                __builder2.AddMarkupContent(39, "<li class=\"nav-item has-treeview\" b-saptvulhc8><a href=\"/home\" class=\"nav-link\" b-saptvulhc8><i class=\"nav-icon fas fa-pencil-alt\" b-saptvulhc8></i>\r\n                                <p b-saptvulhc8>\r\n                                    Library Management\r\n                                    <i class=\"fas fa-angle-left right\" b-saptvulhc8></i></p></a>\r\n                            <ul class=\"nav nav-treeview\" b-saptvulhc8><li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/forms/general.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-book nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Theme</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/forms/advanced.html\" class=\"nav-link\" b-saptvulhc8><i class=\"far fa-circle nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Variable</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/forms/editors.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-sitemap nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Category</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/forms/validation.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-file-alt nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>CRF</p></a></li>\r\n                                <li class=\"nav-item pad20\" b-saptvulhc8><a href=\"pages/forms/validation.html\" class=\"nav-link\" b-saptvulhc8><i class=\"fas fa-map nav-icon\" b-saptvulhc8></i>\r\n                                        <p b-saptvulhc8>Site</p></a></li></ul></li>\r\n                        ");
                __builder2.AddMarkupContent(40, @"<li class=""nav-item has-treeview"" b-saptvulhc8><a href=""#"" class=""nav-link"" b-saptvulhc8><i class=""nav-icon fas fa-newspaper"" b-saptvulhc8></i>
                                <p b-saptvulhc8>
                                    Logs
                                    <i class=""fas fa-angle-left right"" b-saptvulhc8></i></p></a>
                            <ul class=""nav nav-treeview"" b-saptvulhc8><li class=""nav-item pad20"" b-saptvulhc8><a href=""pages/tables/simple.html"" class=""nav-link"" b-saptvulhc8><i class=""fas fa-user-circle nav-icon"" b-saptvulhc8></i>
                                        <p b-saptvulhc8>Online Users</p></a></li>
                                <li class=""nav-item pad20"" b-saptvulhc8><a href=""pages/tables/data.html"" class=""nav-link"" b-saptvulhc8><i class=""far fa-circle nav-icon"" b-saptvulhc8></i>
                                        <p b-saptvulhc8>Access Log</p></a></li>
                                <li class=""nav-item pad20"" b-saptvulhc8><a href=""pages/tables/jsgrid.html"" class=""nav-link"" b-saptvulhc8><i class=""fas fa-file-export nav-icon"" b-saptvulhc8></i>
                                        <p b-saptvulhc8>Dataset Export</p></a></li>
                                <li class=""nav-item pad20"" b-saptvulhc8><a href=""pages/tables/jsgrid.html"" class=""nav-link"" b-saptvulhc8><i class=""fas fa-tasks nav-icon"" b-saptvulhc8></i>
                                        <p b-saptvulhc8>Study Responsibility</p></a></li></ul></li>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 176 "C:\Users\ChinhDo\Working\Workingcurrent\CliresRDMS\CliresWeb\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591