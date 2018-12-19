using System;
using ComicBookShop.Data;
using ComicBookShop.Data.PublisherRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComicBookShop.Tests
{
    [TestClass]
    public class SqlPublisherRepositoryTests
    {
        [TestMethod]
        public void GetPublisherById_Normal_ReturnPublisher()
        {

            SqlPublisherRepository repository = new SqlPublisherRepository(new ShopDbEntities());
            Publisher publisher = repository.GetPublisherById(1);
            
            Publisher expectedPublisher = new Publisher()
            {
                Name = "DC Comics",
                Description = "DC Comics, Inc. is an American comic book publisher. It is the publishing unit of DC Entertainment,[2][3] a subsidiary of Warner Bros. since 1967. DC Comics is one of the largest and oldest American comic book companies, and produces material featuring numerous culturally iconic heroic characters including: Superman, Batman, Wonder Woman, The Flash, Green Lantern, Martian Manhunter, Nightwing, Green Arrow, and Aquaman. ",
                CreationDateTime = new DateTime(1934,01,01)
            };

            Assert.AreEqual(expectedPublisher.Name, publisher.Name);
            Assert.AreEqual(expectedPublisher.Description, publisher.Description);
            Assert.AreEqual(expectedPublisher.CreationDateTime, publisher.CreationDateTime);
        }
    }
}
