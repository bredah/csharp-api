using Api.Controllers;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Api.Tests.Controllers
{
    public class BooksControllerTest
    {
        private readonly List<Book> books;
        private static Guid _defaultGuid = new Guid("585a7950-0632-4fb5-b350-4dc3aed524cd");

        public BooksControllerTest()
        {
            books = new List<Book>()
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

        [Fact]
        public void Get_All_OK()
        {
            var mockService = new Mock<IBookService>();
            var mockResponseContent = books;
            mockService
                .Setup(x => x.Get())
                .Returns(mockResponseContent);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.GetAll() as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            // Check the result typeOf
            Assert.IsType<OkObjectResult>(response);
            // Check if the content has the same type
            var items = Assert.IsType<List<Book>>(response.Value);
            // Check if the content has the same size
            Assert.Equal(mockResponseContent.Count, items.Count);
            // Check if the content has the same values
            Assert.Equal(mockResponseContent, items);
        }

        [Fact]
        public void Get_All_NoReturnValues()
        {
            var mockService = new Mock<IBookService>();
            var mockResponseContent = new List<Book>();
            mockService
                .Setup(x => x.Get())
                .Returns(mockResponseContent);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.GetAll() as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            // Check the result typeOf
            Assert.IsType<OkObjectResult>(response);
            // Check if the content has the same type
            var items = Assert.IsType<List<Book>>(response.Value);
            // Check if the content has the same size
            Assert.Equal(mockResponseContent.Count, items.Count);
            // Check if the content has the same values
            Assert.Equal(mockResponseContent, items);
        }

        [Fact]
        public void Get_ById_OK()
        {
            var mockService = new Mock<IBookService>();
            var mockResponseContent = books[0];
            mockService
                .Setup(x => x.Get(mockResponseContent.Id))
                .Returns(mockResponseContent);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.GetById(mockResponseContent.Id) as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            // Check the result typeOf
            Assert.IsType<OkObjectResult>(response);
            // Check if the content has the same type
            var item = Assert.IsType<Book>(response.Value);
            // Check if the content has the same value
            Assert.Equal(mockResponseContent, item);
        }

        [Fact]
        public void Get_ById_NotFound()
        {
            var mockService = new Mock<IBookService>();
            var guid = new Guid("585a7950-0632-4fb5-b350-4dc3aed524cd");
            mockService
                .Setup(x => x.Get(guid))
                .Returns((Book)null);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.GetById(guid) as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status404NotFound, response.StatusCode);
            // Check the result typeOf
            Assert.IsType<NotFoundObjectResult>(response);
            // Check the response content
            Assert.NotNull(response.Value);
        }

        [Fact]
        public void Post_OK()
        {
            var mockService = new Mock<IBookService>();
            var book = books[0];
            mockService
                .Setup(x => x.Add(book))
                .Returns(book);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.Post(book) as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status201Created, response.StatusCode);
            // Check the result typeOf
            Assert.IsType<CreatedAtActionResult>(response);
            // Check if the content has the same type
            var item = Assert.IsType<Book>(response.Value);
            // Check if the content has the same value
            Assert.Equal(book, item);
        }

        [Theory]
        [MemberData(nameof(InvalidBooks))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void Post_BadRequest(string description, Book book)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            var mockService = new Mock<IBookService>();
            mockService
                .Setup(x => x.Add(book))
                .Returns(book);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.Post(book) as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
            // Check the result typeOf
            Assert.IsType<BadRequestObjectResult>(response);
        }

        public static readonly List<object[]> InvalidBooks = new List<object[]>
        {
            new object[]{"Empty Id", new Book { Id = Guid.Empty, Title = "EXuyRzEcuFJrSSdElUSM", Author = "XTulrhVQIlvjVySwsXTuAsDWWQocXi", Genre = Genre.Comedy}},
            new object[]{"Title has a null value", new Book { Id = _defaultGuid, Title = null, Author = "XTulrhVQIlvjVySwsXTuAsDWWQocXi", Genre = Genre.Comedy }},
            new object[]{"Title than more 20 characters", new Book { Id = _defaultGuid, Title = "EXuyRzEcuFJrSSdElUSMZ", Author = "XTulrhVQIlvjVySwsXTuAsDWWQocXi", Genre = Genre.Comedy }},
            new object[]{"Author has a null value", new Book { Id = _defaultGuid, Title = "EXuyRzEcuFJrSSdElUSM", Author = null, Genre = Genre.Comedy }},
            new object[]{"Author than more 20 characters", new Book { Id = _defaultGuid, Title = "EXuyRzEcuFJrSSdElUSM", Author = "XTulrhVQIlvjVySwsXTuAsDWWQocXiZ", Genre = Genre.Comedy }}
        };
    }
}