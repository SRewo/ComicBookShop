using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShop.Data;

namespace ComicBookShop.Data.PublisherRepositories
{
    public class SqlPublisherRepository : IPublisherRepository
    {
        private ShopDbEntities _context;

        public SqlPublisherRepository()
        {
            _context = new ShopDbEntities();
        }

        public void AddPublisher(Publisher publisher)
        {
            if (publisher.Id == 0)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("You are trying to add publisher which is in database or have an assigned id.");
            }
        }

        public void DeletePublisher(Publisher publisher)
        {
            if (publisher.Id == 0)
            {
                throw new InvalidOperationException("You are trying to delete publisher which is not in database");
            }
            else
            {
                _context.Entry(publisher).State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public Publisher GetPublisherById(int id)
        {
            return _context.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            if (publisher.Id == 0)
            {
                throw new InvalidOperationException("You are trying to edit publisher which is not in database");
            }
            else
            {
                _context.Entry(publisher).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
