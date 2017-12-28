namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1.Bases
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    public abstract class NoteBookBaseController : Controller
    {
        protected SecurityContext SecurityContext
        {
            get {
                StringValues authHeader;
                var authHeaderExists = HttpContext.Request.Headers.TryGetValue("Authorization", out authHeader);
                var token = (authHeaderExists) ? authHeader.ToString().Split(' ')[1] : string.Empty;

                var securityContext = new SecurityContext
                {
                    UserId = User.Identity.Name,
                    Token = token,
                    ApiRoute = HttpContext.Request.Path + HttpContext.Request.QueryString,
                    HttpAction = HttpContext.Request.Method
                };

                return securityContext;
            }
        }
    }
}
