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

            IPublisherRepository repository = new SqlPublisherRepository();
            Publisher publisher = repository.GetPublisherById(1);

            Publisher expectedPublisher = new Publisher()
            {
                Name = "DC Comics",
                CreationDateTime = new DateTime(1934, 01, 01)
            };

            Assert.AreEqual(expectedPublisher.Name, publisher.Name);
            Assert.AreEqual(expectedPublisher.CreationDateTime, publisher.CreationDateTime);
        }

        [TestMethod]
        public void UpdatePublisher_WithoutId_ThrowException()
        {

            IPublisherRepository repository = new SqlPublisherRepository();
            Publisher updatedPublisher = new Publisher()
            {
                Name = "Marvel Comics",
                Description = "Some random Description",
                CreationDateTime = new DateTime(1949, 01, 01)
            };

            Assert.ThrowsException<InvalidOperationException>(() => repository.UpdatePublisher(updatedPublisher));
        }

        [TestMethod]
        public void DeletePublisher_WithoutId_ThrowException()
        {
            IPublisherRepository repository = new SqlPublisherRepository();
            Publisher deletedPublisher = new Publisher()
            {
                Name = "Marvel Comics",
                Description = "Some random Description",
                CreationDateTime = new DateTime(1949, 01, 01)
            };

            Assert.ThrowsException<InvalidOperationException>(() => repository.DeletePublisher(deletedPublisher));
        }

        [TestMethod]
        public void AddPublisher_WithId_ThrowException()
        {
            IPublisherRepository repository = new SqlPublisherRepository();
            Publisher addedPublisher = repository.GetPublisherById(1);

            Assert.ThrowsException<InvalidOperationException>(() =>repository.AddPublisher(addedPublisher));
        }
    }
}
