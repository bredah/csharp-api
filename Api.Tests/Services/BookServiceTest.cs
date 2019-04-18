using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.Tests.Services
{
    public class BookServiceTest : IDisposable
    {
        public BookServiceTest()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json")
                .Build();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void test()
        {

        }
    }
}
