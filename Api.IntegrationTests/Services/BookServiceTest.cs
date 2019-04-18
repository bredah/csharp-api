using Api.Services;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace Api.IntegrationTests.Services
{
    public class BookServiceTest : IDisposable
    {
        private readonly IConfigurationRoot _config;

        public BookServiceTest()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void CheckConnection()
        {
            var service = new BookService(_config);
        }
    }
}
