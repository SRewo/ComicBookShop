using System;
using ComicBookShop.Data.PublisherRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComicBookShop.Data.Test
{
    [TestClass]
    public class SqlPublisherRepositoryTest
    {
        [TestMethod]
        public void GetPublisherById_Normal_ReturnPublisher()
        {

            SqlPublisherRepository repository = new SqlPublisherRepository();
            Publisher publisher = repository.GetPublisherById(1);

            Publisher expectedPublisher = new Publisher()
            {
                Name = "DC Comics",
                Description = "DC Comics, Inc. is an American comic book publisher. It is the publishing unit of DC Entertainment,[2][3] a subsidiary of Warner Bros. since 1967. DC Comics is one of the largest and oldest American comic book companies, and produces material featuring numerous culturally iconic heroic characters including: Superman, Batman, Wonder Woman, The Flash, Green Lantern, Martian Manhunter, Nightwing, Green Arrow, and Aquaman. ",
                CreationDateTime = new DateTime(1934, 01, 01)
            };

            Assert.AreEqual(expectedPublisher.Name, publisher.Name);
            Assert.AreEqual(expectedPublisher.Description, publisher.Description);
            Assert.AreEqual(expectedPublisher.CreationDateTime, publisher.CreationDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddPublisher_AssignedId_ThrowException()
        {

            SqlPublisherRepository repository = new SqlPublisherRepository();
            Publisher insertedPublisher = new Publisher()
            {
                Id = 15000,
                Name = "Marvel Comics",
                Description = "Some random Description",
                CreationDateTime = new DateTime(1949,01,01)
            };

            repository.AddPublisher(insertedPublisher);
        }
    }
}
