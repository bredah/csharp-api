using Api.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Api.Services
{
    public class BookService : IBookService
    {
        private string _keyspace;
        private Cassandra.Cluster _cluster;

        public BookService(IConfiguration config)
        {
            _keyspace = config["ConnectionStrings:keyspace"];
            _cluster = Cassandra.Cluster.Builder()
                .AddContactPoint(config["ConnectionStrings:host"])
                .Build();
        }

        /// <summary>
        /// Retrive a session from database
        /// </summary>
        /// <returns>Database session</returns>
        public Cassandra.ISession GetSession()
        {
            return _cluster.Connect(_keyspace);
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Add(Book book)
        {
            var session = GetSession();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrive a book list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrive a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a book
        /// </summary>
        /// <param name="id"></param>
        public bool Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        public Book Update(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
