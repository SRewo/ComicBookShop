using System.Collections.Generic;

namespace ComicBookShop.Data
{
    public interface IComicBookRepository
    {
        IEnumerable<ComicBook> GetComicBooks();
        ComicBook GeComicBookById(int id);
        void AddComicBook(ComicBook comicBook);
        void UpdateComicBook(ComicBook comicBook);
        void DeleteComicBook(ComicBook comicBook);
    }
}