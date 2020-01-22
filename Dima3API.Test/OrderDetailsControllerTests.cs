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
    public class OrderDetailsControllerTests
    {
        private static DbContextOptions<Dima3APIContext> dbContextOptions { get; }
        private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Dima3DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private Dima3APIContext _context;
        private OrderDetailsController _controller;

        static OrderDetailsControllerTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<Dima3APIContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public OrderDetailsControllerTests()
        {
            _context = new Dima3APIContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(_context);

            _controller = new OrderDetailsController(_context);
        }

        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.GetOrderDetail(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetById_Return_NotFoundResult()
        {
            //Arrange
            var Id = 15;

            //Act
            var result = await _controller.GetOrderDetail(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_CreatedAtActionResult()
        {
            //Arrange
            var orderDetail = new OrderDetail()
            {
                OrderId = 3,
                MenuId = 23,
                Quantity = 2
            };

            //Act
            var result = await _controller.PostOrderDetail(orderDetail);

            //Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var orders = okResult.Value.Should().BeAssignableTo<OrderDetail>().Subject;
            orders.OrderDetailId.Should().Be(6);
        }

        [Fact]
        public async void Task_Delete_ValidData_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.DeleteOrderDetail(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_Update_ValidData_Return_NoContent()
        {
            //Arrange
            var Id = 2;

            //Act
            var existingItem = await _controller.GetOrderDetail(Id);
            if (existingItem == null)
            {
                Assert.IsType<NotFoundResult>(Id);
            }

            var okResult = existingItem.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<OrderDetail>().Subject;

            var orderDetail = new OrderDetail()
            {
                OrderDetailId = result.OrderDetailId,
                OrderId = result.OrderId,
                MenuId = result.MenuId,
                Quantity = 3
            };

            var updatedData = await _controller.PutOrderDetail(Id, orderDetail);

            //Assert
            Assert.IsType<NotFoundResult>(updatedData);
        }
    }
}
