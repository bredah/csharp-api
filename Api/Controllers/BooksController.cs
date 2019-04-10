using Api.Models;
using Api.Services;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }


        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///    GET /Books
        ///    [{
        ///        "id": 1,
        ///        "title": "First book",
        ///        "genre":  "Drama",
        ///        "author": "The first man"
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
                    Id = new Guid("585a7950-0632-4fb5-b350-4dc3aed524cd"),
                    Title = "First book",
                    Genre = Genre.Drama,
                    Author = "The first man"
                },
                new Book()
                {
                    Id = new Guid("0478c3c7-8d59-454b-a978-e6f45d2ed8ca"),
                    Title = "Second book",
                    Genre = Genre.Comedy,
                    Author = "The first man"
                }
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            return new Book()
            {
                Id = new Guid("585a7950-0632-4fb5-b350-4dc3aed524cd"),
                Title = "First book",
                Genre = Genre.Drama,
                Author = "The first man"
            };
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] string value)
        {
            return NoContent();
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <param name="value">Book content value</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] string value)
        {
            return NoContent();
        }

        /// <summary>
        /// Remove a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return NoContent();
        }
    }
}