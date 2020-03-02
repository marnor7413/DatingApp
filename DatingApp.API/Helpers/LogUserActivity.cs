using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // ActionExecutingContext = run code when action IS executed
            // ActionExecutionDelegate = run code AFTER action have executed
            var resultContext = await next();

            // get user id from token
            var userId = int.Parse(resultContext.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value);

            // inject repository (as it is a service declared in startup.cs)
            var repo = resultContext.HttpContext.RequestServices.GetService<IDatingRepository>();            

            var user = await repo.GetUser(userId);
            user.LastActive = DateTime.Now;

            await repo.SaveAll();

        }
    }
}