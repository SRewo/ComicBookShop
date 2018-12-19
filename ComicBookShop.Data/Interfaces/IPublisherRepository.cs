using System.Collections.Generic;

namespace ComicBookShop.Data
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers();
        Publisher GetPublisherById(int id);
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
    }
}