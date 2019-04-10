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
            _keyspace = "";
            _cluster = Cassandra.Cluster.Builder()
                .AddContactPoint("")
                .Build();
        }

        /// <summary>
        /// Retrive a session from database
        /// </summary>
        /// <returns>Database session</returns>
        private Cassandra.ISession GetSession()
        {
            return _cluster.Connect(_keyspace);
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Create(Book book)
        {
            var session = GetSession();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrive a book list
        /// </summary>
        /// <returns></returns>
        public List<Book> Get()
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
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        public void Update(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
