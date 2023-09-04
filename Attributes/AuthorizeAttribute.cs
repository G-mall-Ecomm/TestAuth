using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public string Roles { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (int?)context.HttpContext.Items["User"];

        if (user == null)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }

        if (!string.IsNullOrEmpty(Roles))
        {
            // Replace this with your role validation logic.
            // For now, let's assume you retrieve roles from user ID.
            string userRole = GetUserRole(user.Value);

            if (!Roles.Contains(userRole))
            {
                context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
                return;
            }
        }
    }

    private string GetUserRole(int userId)
    {
        // Dummy logic; you would usually fetch this info from your user service.
        return userId % 2 == 0 ? "Admin" : "User";
    }
}
