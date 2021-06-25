using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Toolbelt.Blazor;

namespace CliresWeb.Services
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor interceptor;
        private readonly NavigationManager navManager;
        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            this.interceptor = interceptor;
            this.navManager = navManager;
        }
        public void RegisterEvent() => interceptor.AfterSend += InterceptResponse;
        private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            if (!e.Response.IsSuccessStatusCode)
            {
                var statusCode = e.Response.StatusCode;
                navManager.NavigateTo("/error/" + (int)statusCode);
                throw new HttpResponseException(statusCode);
            }
        }
        public void DisposeEvent() => interceptor.AfterSend -= InterceptResponse;
    }
}
