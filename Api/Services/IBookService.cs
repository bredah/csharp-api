using Api.Models;
using System;
using System.Collections.Generic;

namespace Api.Services
{
    public interface IBookService
    {
        IEnumerable<Book> Get();
        Book Get(Guid id);
        Book Add(Book book);
        Book Update(Guid id, Book book);
        bool Remove(Guid id);
    }
}
