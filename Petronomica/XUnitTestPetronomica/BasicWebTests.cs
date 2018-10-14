using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using  Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Petronomica;

namespace XUnitTestPetronomica
{
    public class BasicWebTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public BasicWebTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

       
    }
}
