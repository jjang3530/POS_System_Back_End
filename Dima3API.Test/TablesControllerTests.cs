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
    public class TablesControllerTests
    {
        private static DbContextOptions<Dima3APIContext> dbContextOptions { get; }
        private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Dima3DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private Dima3APIContext _context;
        private TablesController _controller;

        static TablesControllerTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<Dima3APIContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public TablesControllerTests()
        {
            _context = new Dima3APIContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(_context);

            _controller = new TablesController(_context);
        }

        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.GetTables(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetById_Return_NotFoundResult()
        {
            //Arrange
            var Id = 15;

            //Act
            var result = await _controller.GetTables(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_CreatedAtActionResult()
        {
            //Arrange
            var table = new Tables()
            {
                TableNumber = "D01",
                Active = "Y"
            };

            //Act
            var result = await _controller.PostTables(table);

            //Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var tables = okResult.Value.Should().BeAssignableTo<Tables>().Subject;
            tables.TableId.Should().Be(13);
        }

        [Fact]
        public async void Task_Delete_ValidData_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.DeleteTables(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_Update_ValidData_Return_NoContent()
        {
            //Arrange
            var Id = 2;

            //Act
            var existingItem = await _controller.GetTables(Id);
            if (existingItem == null)
            {
                Assert.IsType<NotFoundResult>(Id);
            }

            var okResult = existingItem.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Tables>().Subject;

            var table = new Tables()
            {
                TableId = result.TableId,
                TableNumber = "E04",
                Active = result.Active
            };


            var updatedData = await _controller.PutTables(Id, table);

            //Assert
            Assert.IsType<NotFoundResult>(updatedData);
        }
    }
}
