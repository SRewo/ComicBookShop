using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComicBookShop.Data.Repositories;

namespace ComicBookShop.Data.Test
{
    [TestClass]
    public class OrderItemTests
    {
        [TestMethod]
        public void Validation_ComicBook_IsNull()
        {
            OrderItem item = new OrderItem()
            {
                ComicBook = null,
                Discount = 10,
                Quantity = 10
            };

            var expectedMessage = "Comic Book can't be null or empty.";


            Assert.IsTrue(item.HasErrors);
            Assert.AreEqual(expectedMessage, item.GetFirstError("ComicBook"));
        }

        [TestMethod]
        public void Validation_Quantity_IsNegative()
        {
            OrderItem item = new OrderItem()
            {
                ComicBook = new ComicBook(),
                Discount = 0,
                Quantity = -10
            };

            var expectedMessage = "Please enter valid value.";

            Assert.IsTrue(item.HasErrors);
            Assert.AreEqual(expectedMessage, item.GetFirstError("Quantity"));
        }

        [TestMethod]
        public void Validation_Discount_IsOverRange()
        {
            OrderItem item = new OrderItem()
            {
                ComicBook = new ComicBook(),
                Discount = 400,
                Quantity = 10
            };

            var expectedMessage = "Please enter valid value.";

            Assert.IsTrue(item.HasErrors);
            Assert.AreEqual(expectedMessage, item.GetFirstError("Discount"));
        }

        [TestMethod]
        public void Validation_Discount_IsNegative()
        {
            OrderItem item = new OrderItem()
            {
                ComicBook = new ComicBook(),
                Discount = -10,
                Quantity = 10
            };

            var expectedMessage = "Please enter valid value.";

            Assert.IsTrue(item.HasErrors);
            Assert.AreEqual(expectedMessage, item.GetFirstError("Discount"));
        }

        [TestMethod]
        public void Price_ReturnsValidValue()
        {
            OrderItem item = new OrderItem()
            {
                ComicBook = new ComicBook()
                {
                    Price = 10
                },
                Discount = 0,
                Quantity = 10
            };

            OrderItem item2 = new OrderItem()
            {
                ComicBook = new ComicBook()
                {
                    Price = 10
                },
                Discount = 10,
                Quantity = 10
            };



            var expectedPrice = 100;
            var expectedPrice2 = 90;

            Assert.AreEqual(expectedPrice2, item2.Price);
            Assert.AreEqual(expectedPrice, item.Price);
        }

    }
}
