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
    //this is our MenusControllerTest
    public class MenusControllerTests
    {
        private static DbContextOptions<Dima3APIContext> dbContextOptions { get; }
        private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Dima3DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private Dima3APIContext _context;
        private MenusController _controller;

        static MenusControllerTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<Dima3APIContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public MenusControllerTests()
        {
            _context = new Dima3APIContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(_context);

            _controller = new MenusController(_context);
        }

        [Fact]
        public async void Task_GetById_Return_OkResult()
        {
            //Arrange
            var Id = 36;

            //Act
            var result = await _controller.GetMenus(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetById_Return_NotFoundResult()
        {
            //Arrange
            var Id = 37;

            //Act
            var result = await _controller.GetMenus(Id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_CreatedAtActionResult()
        {
            //Arrange
            var menu = new Menus()
            {
                MenuName = "TestMenu",
                UnitPrice = 4.25m,
                ThumbPic = "",
                LargePic = "",
                Active = "N"
            };

            //Act
            var result = await _controller.PostMenus(menu);

            //Assert
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var menus = okResult.Value.Should().BeAssignableTo<Menus>().Subject;
            menus.MenuId.Should().Be(37);
        }

        [Fact]
        public async void Task_Delete_ValidData_Return_OkResult()
        {
            //Arrange
            var Id = 2;

            //Act
            var result = await _controller.DeleteMenus(Id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_Update_ValidData_Return_NoContent()
        {
            //Arrange
            var Id = 2;

            //Act
            var existingItem = await _controller.GetMenus(Id);
            if (existingItem == null)
            {
                Assert.IsType<NotFoundResult>(Id);
            }

            var okResult = existingItem.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Menus>().Subject;

            var menus = new Menus()
            {
                MenuId = result.MenuId,
                MenuName = "test",
                UnitPrice = result.UnitPrice,
                ThumbPic = result.ThumbPic,
                LargePic = result.LargePic,
                Active = "N"
            };

            //_context.Menus.Attach(menus);
            var updatedData = await _controller.PutMenus(Id, menus);

            //Assert
            Assert.IsType<NotFoundResult>(updatedData);
        }
    }
}
