using APICrud.Controllers;
using APICrud.Models;
using APICrud.Service;
using APICrud.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApiCrudUnitTest
{
    public class CustomerunitTest
    {
        private readonly CustomerController _controller;
        private readonly CustomerService _service;
        private readonly IUnitOfWork _unitofwork;

        public CustomerunitTest()
        {
            _service = new CustomerService(_unitofwork);
            _controller = new CustomerController(_service);
        }

        [Fact]
        public void GetAllCustomers_ReturnsOkResult()
        {
            // Arrange

            // Act
            var result = _controller.GetAllCustomers();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllCustomers_ReturnsAllItems()
        {
            // Arrange

            // Act
            var result = _controller.GetAllCustomers().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Customer>>(result.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetCustomerById_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 999;

            // Act
            var result = _controller.GetCustomerById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetCustomerById_ReturnsOkResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.GetCustomerById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetCustomerById_ReturnsRightItem()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.GetCustomerById(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<Customer>(result.Value);
            Assert.Equal(id, (result.Value as Customer).CustomerId);
        }

        [Fact]
        public void CreateCustomer_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var customer = new Customer { CustomerId = 4, CustomerName = "Jane" };

            // Act
            var result = _controller.CreateCustomer(customer);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void UpdateCustomer_ReturnsNoContentResult()
        {
            // Arrange
            var id = 1;
            var customer = new Customer { CustomerId = id, CustomerName = "John" };

            // Act
            var result = _controller.UpdateCustomer(id, customer);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteCustomer_ReturnsNoContentResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.DeleteCustomer(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
