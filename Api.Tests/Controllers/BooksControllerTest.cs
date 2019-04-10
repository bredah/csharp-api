using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Api.Tests.Controllers
{
    public class BooksControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient Client { get; }

        public BooksControllerTest(WebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }


        [Fact]
        public async Task Test1()
        {
            var response = await Client
                .GetAsync($"api/values");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Validate response content
            var json = await response.Content.ReadAsStringAsync();
            dynamic responseContent = JObject.Parse(json);
        }
    }
}