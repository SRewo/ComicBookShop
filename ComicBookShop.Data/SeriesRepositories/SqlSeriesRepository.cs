using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public void DeleteSeries(Series series)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Series> GetSeries()
        {
            return _context.Series.ToList();
        }

        public Series GetSeriesById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSeries(Series series)
        {
            throw new System.NotImplementedException();
        }
    }
}