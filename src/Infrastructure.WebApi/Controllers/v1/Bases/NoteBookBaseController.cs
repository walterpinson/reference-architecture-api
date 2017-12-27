namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers.v1.Bases
{
    using System;
    using CompanyName.Notebook.NoteTaking.Core.Application.Messages;
    using Microsoft.AspNetCore.Mvc;

    public abstract class NoteBookBaseController : Controller
    {
        protected SecurityContext SecurityContext
        {
            get {
                var securityContext = new SecurityContext
                {
                    UserId = User.Identity.Name,
                    Token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1],
                    ApiRoute = HttpContext.Request.Path + HttpContext.Request.QueryString,
                    HttpAction = HttpContext.Request.Method
                };

                return securityContext;
            }
        }
    }
}
