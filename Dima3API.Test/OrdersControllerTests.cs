using System;
using System.Collections.Generic;
using System.Text;
using Dima3API.Data;
using Dima3API.Models;
using Dima3API.Controllers;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Dima3API.Test
{
    public class OrdersControllerTests
    {
        private static DbContextOptions<Dima3APIContext> dbContextOptions { get; }
        private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Dima3DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private Dima3APIContext _context;
        private OrdersController _controller;

        static OrdersControllerTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<Dima3APIContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public OrdersControllerTests()
        {
            _context = new Dima3APIContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(_context);

            _controller = new OrdersController(_context);
        }

        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.GetOrders(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetById_Return_NotFoundResult()
        {
            //Arrange
            var Id = 15;

            //Act
            var result = await _controller.GetOrders(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_CreatedAtActionResult()
        {
            //Arrange
            var order = new Orders()
            {
                OrderDate = DateTime.Now,
                TableId = 6
            };

            //Act
            var result = await _controller.PostOrders(order);

            //Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var orders = okResult.Value.Should().BeAssignableTo<Orders>().Subject;
            orders.OrderId.Should().Be(4);
        }

        [Fact]
        public async void Task_Delete_ValidData_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.DeleteOrders(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_Update_ValidData_Return_NoContent()
        {
            //Arrange
            var Id = 2;

            //Act
            var existingItem = await _controller.GetOrders(Id);
            if (existingItem == null)
            {
                Assert.IsType<NotFoundResult>(Id);
            }

            var okResult = existingItem.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Orders>().Subject;

            var order = new Orders()
            {
                OrderId = result.OrderId,
                OrderDate = result.OrderDate,
                TableId = 0
            };

            var updatedData = await _controller.PutOrders(Id, order);

            //Assert
            Assert.IsType<NotFoundResult>(updatedData);
        }
    }
}
