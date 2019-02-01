using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComicBookShop.Data.Repositories;

namespace ComicBookShop.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var dataContext = new ShopDbEntities())
            {
                var publishers = new SqlRepository<Publisher>(dataContext);

                Publisher publisher = publishers.GetById(1);

                Assert.AreEqual("DC Comics", publisher.Name);
            }
            
        }
    }
}
