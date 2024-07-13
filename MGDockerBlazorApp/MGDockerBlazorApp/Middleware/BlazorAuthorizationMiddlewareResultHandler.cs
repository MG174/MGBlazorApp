using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace MGDockerBlazorApp.Middleware
{
    public class BlazorAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private ILocalStorageService _LocalStorage;

        public BlazorAuthorizationMiddlewareResultHandler(ILocalStorageService LocalStorage)
        {
            _LocalStorage = LocalStorage;
        }

        public Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            return next(context);
        }
    }
}
