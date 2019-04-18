using Api.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Api.IntegrationTests.Services
{
    public class ConnectionFactoryTest
    {
        private readonly IConfigurationRoot _config;

        public ConnectionFactoryTest()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [Fact]
        public void CheckConnection()
        {
            new ConnectionFactory(_config).GetSession(_config["ConnectionStrings:keyspace"]);
        }

        [Fact]
        public void CheckConnection_Exception_KeyspaceIsNull()
        {
            //var service = new ConnectionFactory(_config).GetSession(_config["ConnectionStrings:keyspace"]);
            Assert.Throws<System.ArgumentException>(() => new ConnectionFactory(_config).GetSession(null));
        }

        [Fact]
        public void CheckConnection_Exception_KeyspaceIsVoid()
        {
            //var service = new ConnectionFactory(_config).GetSession(_config["ConnectionStrings:keyspace"]);
            Assert.Throws<System.ArgumentException>(() => new ConnectionFactory(_config).GetSession(""));
        }

        [Fact]
        public void CheckConnection_Exception_InvalidKeyspace()
        {
            //var service = new ConnectionFactory(_config).GetSession(_config["ConnectionStrings:keyspace"]);
            Assert.Throws<Cassandra.InvalidQueryException>(() => new ConnectionFactory(_config).GetSession("xpto"));
        }

    }
}
