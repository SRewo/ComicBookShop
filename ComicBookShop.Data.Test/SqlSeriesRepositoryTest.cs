using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComicBookShop.Data.SeriesRepositories;

namespace ComicBookShop.Data.Test
{
    [TestClass]
    public class SqlSeriesRepositoryTest
    {
        [TestMethod]
        public void GetSeriesById_Normal_ReturnSeries()
        {
            ISeriesRepository repository = new SqlSeriesRepository();
            Series series = repository.GetSeriesById(1);
            

            Assert.AreEqual("DARK NIGHTS: METAL 2017",series.Name);
            Assert.AreEqual("DC Comics",series.Publisher.Name);
        }
    }
}
