using Cassandra;
using Microsoft.Extensions.Configuration;

namespace Api.Services
{
    public class ConnectionFactory
    {
        private readonly Cluster _cluster;

        public ConnectionFactory(IConfiguration config)
        {
            _cluster = Cassandra.Cluster.Builder()
             .AddContactPoint(config["ConnectionStrings:host"])
             .Build();
        }

        public ISession GetSession(string keyspace)
        {
            if (string.IsNullOrEmpty(keyspace)) { throw new System.ArgumentException("Need to set a value"); }
            return _cluster.Connect(keyspace);
        }
    }
}
