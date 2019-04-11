using Api.Controllers;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Controllers
{
    public class BooksControllerTest
    {
        [Fact]
        public void GetAll_ReturnAllValues()
        {
            var mockService = new Mock<IBookService>();
            var mockResponseContent = new List<Book>()
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
            mockService
                .Setup(x => x.Get())
                .Returns(mockResponseContent);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.GetAll() as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            // Check if the content has the same type
            var items = Assert.IsType<List<Book>>(response.Value);
            // Check if the content has the same size
            Assert.Equal(mockResponseContent.Count, items.Count);
            // Check if the content has the same values
            Assert.Equal(mockResponseContent, items);
        }

        [Fact]
        public void GetAll_NoReturnValues()
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
            // Check if the content has the same type
            var items = Assert.IsType<List<Book>>(response.Value);
            // Check if the content has the same size
            Assert.Equal(mockResponseContent.Count, items.Count);
            // Check if the content has the same values
            Assert.Equal(mockResponseContent, items);
        }

        [Fact]
        public void GetById()
        {
            var mockService = new Mock<IBookService>();
            var guid = new Guid("585a7950-0632-4fb5-b350-4dc3aed524cd");
            var mockResponseContent = new Book()
            {
                Id = guid,
                Title = "First book",
                Genre = Genre.Drama,
                Author = "The first man"
            };

            mockService
                .Setup(x => x.Get(guid))
                .Returns(mockResponseContent);
            // Inject the mock in the controller
            var controller = new BookController(mockService.Object);
            // Get the response
            var response = controller.GetById(guid) as ObjectResult;
            // Check the status code
            Assert.Equal(StatusCodes.Status200OK, response.StatusCode);
            // Check if the content has the same type
            var item = Assert.IsType<Book>(response.Value);
            // Check if the content has the same value
            Assert.Equal(mockResponseContent, item);
        }

        [Fact]
        public void GetById_NotFound()
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
        }
    }
}