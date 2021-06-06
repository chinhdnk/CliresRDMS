using Infrastructure.Models;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories.ApiClient
{
    public interface IWebApiExecuter
    {
        Task InvokeDelete(string uri);
        Task<T> InvokeGet<T>(string uri);
        Task<T> InvokeLoginPost<T>(string uri, AuthenticateRequest obj);
        Task<T> InvokePost<T>(string uri, T obj);
        Task<string> InvokePostReturnString<T>(string uri, T obj);
        Task InvokePut<T>(string uri, T obj);
    }
}