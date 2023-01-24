using eCInema.Models.Entities;
using eCInema.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eCinema.Web.API.Auth
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute(params UserRole[] roles)
        {
            var allowedRolesAsStrings = roles.Select(x => Enum.GetName(typeof(UserRole), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || (Roles.Any() && !Roles.Contains((char)user.UserRole)))
            {
                // not logged in or role not authorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
