using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;

namespace Tests.Integration
{
    public class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _client;

        public IntegrationTestBase(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient(); // starts the in-memory server
        }
    }
}