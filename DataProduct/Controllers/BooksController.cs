using System.Collections.Generic;
using DataProduct.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataProduct.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///    GET /Books
        ///    [{
        ///        "id": 1,
        ///        "title": "First book",
        ///        "gender":  "Drama",
        ///        "writer": "The first man"
        ///    }] 
        /// </remarks>
        /// <returns>A list with all existing books</returns>
        /// <response code="200">Returns the list</response>
        /// <response code="400">If not exist a book</response>            
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<Book>> GetAll()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "First book",
                    Gender = Gender.Drama,
                    Writer = "The first man"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Second book",
                    Gender = Gender.Comedy,
                    Writer = "The first man"
                }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            return new Book()
            {
                Id = 1,
                Title = "First book",
                Gender = Gender.Drama,
                Writer = "The first man"
            };
        }
    }
}