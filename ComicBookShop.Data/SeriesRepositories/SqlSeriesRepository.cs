using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ComicBookShop.Data.SeriesRepositories
{
    public class SqlSeriesRepository : ISeriesRepository
    {
        private ShopDbEntities _context;

        public SqlSeriesRepository()
        {
            _context = new ShopDbEntities();
        }

        public void AddSeries(Series series)
        {
            if (series.Id == 0)
            {
                _context.Series.Add(series);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("You are trying to add series which is already in database or have assigned id");
            }
        }

        public void DeleteSeries(Series series)
        {
            if (series.Id != 0)
            {
                _context.Entry(series).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("You are trying to delete series which is not in database");
            }
        }

        public IEnumerable<Series> GetSeries()
        {
            return _context.Series.ToList();
        }

        public Series GetSeriesById(int id)
        {
            return _context.Series.Find(id);
        }

        public void UpdateSeries(Series series)
        {
            if (series.Id != 0)
            {
                _context.Entry(series).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("You are trying to modify series which is not in database");
            }
        }
    }
}