using Api.Models;
using System;
using System.Collections.Generic;

namespace Api.Services
{
    public interface IBookService
    {
        List<Book> Get();
        Book Get(Guid id);
        Book Create(Book book);
        void Update(Guid id, Book book);
        void Remove(Guid id);
    }
}
