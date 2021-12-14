using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NUnit.Framework;

namespace Application.Helpers
{
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
             object entity = null;
             foreach (var permission in _permissions)
             {
                if(entity == null && permission == Permissions.Teacher)
                {
                    entity = (Teacher)context.HttpContext.Items["Teacher"];
                }
                if(entity == null && permission == Permissions.Student)
                {
                    entity = (Student)context.HttpContext.Items["Student"];
                }
             }
             if (entity == null)
             {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
             }
        }
    }
}