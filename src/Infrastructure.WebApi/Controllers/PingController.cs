namespace CompanyName.Notebook.NoteTaking.Infrastructure.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api")]
    public class PingController : Controller
    {
        [HttpGet]
        [Route("ping")]
        public string Ping() => $"PING! The server is alive.";

        [Authorize("")]
        [HttpGet]
        [Route("ping/secure")]
        public string PingSecured() => $"All good: {User.Identity.Name}. You only get this message if you are authenticated.";
    }
}