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
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _service.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Book value)
        {
            if (!ModelState.IsValid)
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