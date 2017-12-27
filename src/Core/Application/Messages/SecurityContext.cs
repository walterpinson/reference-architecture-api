namespace CompanyName.Notebook.NoteTaking.Core.Application.Messages
{
    public class SecurityContext
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string HttpAction { get; set; }
        public string ApiRoute { get; set; }
    }
}