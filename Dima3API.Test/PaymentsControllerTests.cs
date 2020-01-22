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
    public class PaymentsControllerTests
    {
        private static DbContextOptions<Dima3APIContext> dbContextOptions { get; }
        private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Dima3DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private Dima3APIContext _context;
        private PaymentsController _controller;

        static PaymentsControllerTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<Dima3APIContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public PaymentsControllerTests()
        {
            _context = new Dima3APIContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(_context);

            _controller = new PaymentsController(_context);
        }

        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            //Arrange
            var Id = 1;

            //Act
            var result = await _controller.GetPayments(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetById_Return_NotFoundResult()
        {
            //Arrange
            var Id = 15;

            //Act
            var result = await _controller.GetPayments(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_CreatedAtActionResult()
        {
            //Arrange
            var payment = new Payments()
            {
                OrderId = 2,
                PaymentDate = DateTime.Now,
                Amount = 13.5m
            };

            //Act
            var result = await _controller.PostPayments(payment);

            //Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var payments = okResult.Value.Should().BeAssignableTo<Payments>().Subject;
            payments.PaymentId.Should().Be(2);
        }

        [Fact]
        public async void Task_Delete_ValidData_Return_OkResult()
        {
            //Arrange
            var Id = 1;

            //Act
            var result = await _controller.DeletePayments(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_Update_ValidData_Return_NoContent()
        {
            //Arrange
            var Id = 1;

            //Act
            var existingItem = await _controller.GetPayments(Id);
            if (existingItem == null)
            {
                Assert.IsType<NotFoundResult>(Id);
            }

            var okResult = existingItem.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Payments>().Subject;

            var payment = new Payments()
            {
                PaymentId = result.PaymentId,
                OrderId = result.OrderId,
                PaymentDate = DateTime.Now,
                Amount = 13.5m
            };

            var updatedData = await _controller.PutPayments(Id, payment);

            //Assert
            Assert.IsType<NotFoundResult>(updatedData);
        }
    }
}
