namespace Test.Unit.Infrastructure.WebApi.Controllers.Bases
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Security.Principal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using NSubstitute;
    using NUnit.Framework;

    public abstract class ControllerTesterTemplate<TContext> where TContext : Controller
    {
        protected virtual TContext _subjectUnderTest { get; private set; }
        private const string _rootPath = "/basepath";

        protected static Uri _baseUri
        {
            get { return new Uri("http://localhost:4000"); }
        }

        protected HttpContext _httpContext { get; private set; }
        protected HttpRequest _request { get; private set; }
        protected HttpResponse _response { get; private set; }
        protected IIdentity _identity { get; private set; }

        [SetUp]
        public virtual void SetUp()
        {
            _subjectUnderTest = EstablishContext();
            _subjectUnderTest.ControllerContext = FakeControllerContext(_subjectUnderTest);
            _subjectUnderTest.Url = new UrlHelper(_subjectUnderTest.ControllerContext);
        }

        [TearDown]
        public void Teardown()
        {
            _httpContext.ClearReceivedCalls();
            _request.ClearReceivedCalls();
            _response.ClearReceivedCalls();
            _identity.ClearReceivedCalls();

            TestCleanup();
        }

        protected abstract TContext EstablishContext();
        protected abstract void TestCleanup();

       private ControllerContext FakeControllerContext(ControllerBase controller)
        {
            InitialiseFakeHttpContext();
            var routeData = new RouteData();
            routeData.Values.Add("key1", "value1");
            var actionContext = new ActionContext(_httpContext, routeData, new ControllerActionDescriptor());
            return new ControllerContext(actionContext);
        }

        private void InitialiseFakeHttpContext(string url = "")
        {
            _identity = Substitute.For<IIdentity>();
            var principal = new ClaimsPrincipal(_identity);
            var items = Substitute.For<IDictionary<Object, Object>>();
            
            _httpContext = Substitute.For<HttpContext>();
            _request = Substitute.For<HttpRequest>();
            _response = Substitute.For<HttpResponse>();
            _httpContext.Request.Returns(_request);
            _httpContext.Response.Returns(_response);
            _httpContext.User.Returns(principal);
            _httpContext.Items.Returns(items);

            // Initialize the Request
            // Initialize User.Identity.Name value for the controller context.
            _identity.Name.Returns("peoplefluent|00112233445566");

            // Initialize the request headers
            var headers = new HeaderDictionary();
            headers.Add("Authorization", "Bearer abc123");
            _request.Headers.Returns(headers);

            // Initialize the request method and path
            _request.Method = "GET";
            _request.Path = "/api/v1/categories";
            _request.QueryString = new QueryString("");
        }
    }
}