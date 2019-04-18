using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }


        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///    GET /books
        ///    [{
        ///        "id": 1,
        ///        "title": "First book",
        ///        "genre":  "Drama",
        ///        "author": "The first man"
        ///    }] 
        /// </remarks>
        /// <returns>A list with all existing books</returns>
        /// <response code="200">Returns the list</response>
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _service.Get();
            return Ok(result);
        }

        /// <summary>
        /// Retrive a specific book
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///    GET /books?id=ID
        ///    {
        ///        "id": 1,
        ///        "title": "First book",
        ///        "genre":  "Drama",
        ///        "author": "The first man"
        ///    } 
        /// </remarks>
        /// <param name="id">Book id</param>
        /// <returns>Return a book if exists</returns>
        /// <response code="200">The book info</response>
        /// <response code="404">The book does not exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound($"This book does not exist");
            }
            return Ok(item);
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] Book value)
        {
            if (!ModelState.IsValid || value.Id == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id">Book ID</param>
        /// <param name="value">Book content value</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Book value)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            item = _service.Update(id, value);
            return AcceptedAtAction("Get", new { id = item.Id }, item);
        }

        /// <summary>
        /// Remove a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok();
        }
    }
}