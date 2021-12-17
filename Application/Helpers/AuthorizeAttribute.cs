using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Helpers
{
    /**
     * Attribut permettant de vérifier si l'utilisateur a les droits d'effectuer la requête
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly List<Permissions> _permissions = new();

        public AuthorizeAttribute(Permissions[] permissions)
        {
            _permissions.AddRange(permissions);
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Si entity = null et que l'utilisateur possède l'une des permissions, on affecte le type d'utilisateur à entity
            var entity = _permissions.Aggregate<Permissions, object>(null, (current, permission) => current switch
            {
                null when permission == Permissions.Admin => context.HttpContext.Items["Admin"],
                null when permission == Permissions.Teacher => context.HttpContext.Items["Teacher"],
                null when permission == Permissions.Student => context.HttpContext.Items["Student"],
                _ => current
            });
            
            if (entity == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}