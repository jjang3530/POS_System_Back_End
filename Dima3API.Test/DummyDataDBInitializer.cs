using System;
using System.Collections.Generic;
using System.Text;
using Dima3API.Data;
using Dima3API.Models;

namespace Dima3API.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(Dima3APIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
                       
            var lstTable = GetTables().ToArray();
            context.Tables.AddRange(lstTable);
            context.SaveChanges();

            var lstMenu = GetMenus().ToArray();
            context.Menus.AddRange(lstMenu);
            context.SaveChanges();

            var lstOrder = GetOrders().ToArray();
            context.Orders.AddRange(lstOrder);
            context.SaveChanges();

            var lstOrderDetail = GetOrderDetails().ToArray();
            context.OrderDetail.AddRange(lstOrderDetail);
            context.SaveChanges();

            var lstPayment = GetPayments().ToArray();
            context.Payments.AddRange(lstPayment);
            context.SaveChanges();
        }
              

        public static List<Tables> GetTables()
        {
            List<Tables> lstTable = new List<Tables>() {
            new Tables { TableNumber = "A01", Active = "Y"},
            new Tables { TableNumber = "A02", Active = "Y"},
            new Tables { TableNumber = "A03", Active = "Y"},
            new Tables { TableNumber = "A04", Active = "Y"},
            new Tables { TableNumber = "B01", Active = "Y"},
            new Tables { TableNumber = "B02", Active = "Y"},
            new Tables { TableNumber = "B03", Active = "Y"},
            new Tables { TableNumber = "B04", Active = "Y"},
            new Tables { TableNumber = "C01", Active = "Y"},
            new Tables { TableNumber = "C02", Active = "Y"},
            new Tables { TableNumber = "C03", Active = "Y"},
            new Tables { TableNumber = "C04", Active = "Y"}
            };

            return lstTable;
        }

        public static List<Menus> GetMenus()
        {
            List<Menus> lstMenu = new List<Menus>() {
            new Menus { MenuName = "Gunkan",        UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th01.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/01.jpg",  Active = "Y"},
            new Menus { MenuName = "Temaki",        UnitPrice = 6.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th02.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/02.jpg",  Active = "Y"},
            new Menus { MenuName = "Narezushi",     UnitPrice = 5.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th03.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/03.jpg",  Active = "Y"},
            new Menus { MenuName = "Nigiri",        UnitPrice = 5.35m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th04.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/04.jpg",  Active = "Y"},
            new Menus { MenuName = "Daiquiri",      UnitPrice = 6.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th05.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/05.jpg",  Active = "Y"},
            new Menus { MenuName = "Margarita",     UnitPrice = 6.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th06.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/06.jpg",  Active = "Y"},
            new Menus { MenuName = "Bloody Mary",   UnitPrice = 6.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th07.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/07.jpg",  Active = "Y"},
            new Menus { MenuName = "Cosmopolitan",  UnitPrice = 6.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th08.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/08.jpg",  Active = "Y"},
            new Menus { MenuName = "Pound",         UnitPrice = 4.50m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th09.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/09.jpg",  Active = "Y"},
            new Menus { MenuName = "Sponge",        UnitPrice = 4.50m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th10.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/10.jpg",  Active = "Y"},
            new Menus { MenuName = "Genoise",       UnitPrice = 4.50m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th11.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/11.jpg",  Active = "Y"},
            new Menus { MenuName = "Biscuit",       UnitPrice = 4.50m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th12.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/12.jpg",  Active = "Y"},
            new Menus { MenuName = "Amaebi",        UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th13.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/13.jpg",  Active = "Y"},
            new Menus { MenuName = "Anago",         UnitPrice = 5.75m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th14.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/14.jpg",  Active = "Y"},
            new Menus { MenuName = "Aoyagi",        UnitPrice = 5.85m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th15.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/15.jpg",  Active = "Y"},
            new Menus { MenuName = "Bincho",        UnitPrice = 6.15m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th16.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/16.jpg",  Active = "Y"},
            new Menus { MenuName = "Katsuo",        UnitPrice = 6.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th17.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/17.jpg",  Active = "Y"},
            new Menus { MenuName = "Ebi",           UnitPrice = 6.35m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th18.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/18.jpg",  Active = "Y"},
            new Menus { MenuName = "Escolar",       UnitPrice = 6.45m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th19.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/19.jpg",  Active = "Y"},
            new Menus { MenuName = "Hamachi",       UnitPrice = 7.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th20.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/20.jpg",  Active = "Y"},
            new Menus { MenuName = "Hirame",        UnitPrice = 8.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th21.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/21.jpg",  Active = "Y"},
            new Menus { MenuName = "Hokigai",       UnitPrice = 9.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th22.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/22.jpg",  Active = "Y"},
            new Menus { MenuName = "Hotate",        UnitPrice = 9.15m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th23.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/23.jpg",  Active = "Y"},
            new Menus { MenuName = "Ikura",         UnitPrice = 7.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th24.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/24.jpg",  Active = "Y"},
            new Menus { MenuName = "Iwashi",        UnitPrice = 6.75m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th25.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/25.jpg",  Active = "Y"},
            new Menus { MenuName = "Kani",          UnitPrice = 8.15m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th26.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/26.jpg",  Active = "Y"},
            new Menus { MenuName = "Kanpachi",      UnitPrice = 4.55m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th27.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/27.jpg",  Active = "Y"},
            new Menus { MenuName = "Maguro",        UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th28.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/28.jpg",  Active = "Y"},
            new Menus { MenuName = "Saba",          UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th29.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/29.jpg",  Active = "Y"},
            new Menus { MenuName = "Sake",          UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th30.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/30.jpg",  Active = "Y"},
            new Menus { MenuName = "Tako",          UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th31.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/31.jpg",  Active = "Y"},
            new Menus { MenuName = "Oshizushi",     UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th32.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/32.jpg",  Active = "Y"},
            new Menus { MenuName = "Tamago",        UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th33.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/32.jpg",  Active = "Y"},
            new Menus { MenuName = "Toro",          UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th34.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/32.jpg",  Active = "Y"},
            new Menus { MenuName = "Tsubugai",      UnitPrice = 5.65m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th35.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/32.jpg",  Active = "Y"},
            new Menus { MenuName = "Unagi",         UnitPrice = 5.25m,   ThumbPic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/thumbs/th36.jpg",    LargePic = "http://yes-restaurants.com/gallery/yes_sushi/waterloo/36.jpg",  Active = "Y"}
            };

            return lstMenu;
        }

        public static List<Orders> GetOrders()
        {
            List<Orders> lstOrder = new List<Orders>() {
            new Orders { OrderDate = DateTime.Now, TableId = 1, OrderStatus = "Completed"},
            new Orders { OrderDate = DateTime.Now, TableId = 2},
            new Orders { OrderDate = DateTime.Now, TableId = 3}
            };
            return lstOrder;
        }

        public static List<OrderDetail> GetOrderDetails()
        {
            List<OrderDetail> lstOrderDetail = new List<OrderDetail>() {
            new OrderDetail { OrderId = 1, MenuId = 20, Quantity = 3},
            new OrderDetail { OrderId = 1, MenuId = 25, Quantity = 2},
            new OrderDetail { OrderId = 2, MenuId = 7,  Quantity = 1},
            new OrderDetail { OrderId = 2, MenuId = 25, Quantity = 1},
            new OrderDetail { OrderId = 3, MenuId = 19, Quantity = 1}
            };
            return lstOrderDetail;
        }

        public static List<Payments> GetPayments()
        {
            List<Payments> lstPayment = new List<Payments>()
            {
                new Payments { OrderId = 1, PaymentDate = DateTime.Now, Amount = 30.0m },
            };
            return lstPayment;
        }

    }
}
