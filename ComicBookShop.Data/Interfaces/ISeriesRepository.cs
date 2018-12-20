using System.Collections.Generic;

namespace ComicBookShop.Data
{
    public interface ISeriesRepository
    {
        IEnumerable<Series> GetSeries();
        Series GetSeriesById(int id);
        void AddSeries(Series series);
        void UpdateSeries(Series series);
        void DeleteSeries(Series series);
    }
}