using e_library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class BookRepository : BaseRepository
    {
        // Вывести все книги
        public List<Book> SelectAllBooks()
        {
            return db.Books.ToList();
        }

        // Выбор книги по id
        public Book SelectBookByID(int ID)
        {
            return db.Books.Where(book => book.ID == ID).FirstOrDefault();
        }

        // Добавление книги в бд
        public bool AddNewBook(Book book)
        {
            try
            {
                db.Books.Add(book);
            }
            catch (Exception)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }

        // Удаление книги из БД
        public bool DeleteBook(Book book)
        {
            try
            {
                db.Books.Remove(book);
            }
            catch (Exception)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }

        // изменить год выпуска у книги
        public bool UpdateBookDateByID(int ID, int year)
        {
            var book = db.Books.Where(book => book.ID == ID).FirstOrDefault();

            if (book != null) book.ReleaseYser = year;
            else return false;

            db.SaveChanges();

            return true;
        }

        // Получить список книг определенного жанра и вышедших между определенными годами
        public List<Book> GetBooksByGenreAndYears(string genre, int yearFrom, int yearTo)
        {
            return db.Books.Include(g => g.Genre).Include(a => a.Author)
                    .Where(book => book.Genre.Name == genre && book.ReleaseYser >= yearFrom 
                     && book.ReleaseYser <= yearTo)
                    .ToList();
        }

        // Получить количество книг определенного автора в библиотеке
        public int GetCountOfBooksByAuthor(string surName, string name)
        {
            return db.Books.Include(a => a.Author)
                    .Count(book => book.Author.Name == name && book.Author.SurName == surName);
        }

        // Получить количество книг определенного жанра в библиотеке
        public int GetCountOfBooksByGenre(string genreName)
        {
            return db.Books.Include(a => a.Genre)
                    .Count(book => book.Genre.Name == genreName);
        }

        // Получить булевый флаг о том,
        // есть ли книга определенного автора и с определенным названием в библиотеке
        public bool GetFlagOfBookByAuthorAndTitle(string authorSurName, string authorName, string bookName)
        {
            return db.Books.Include(a => a.Author)
                    .Any(book => book.Title == bookName && book.Author.Name == authorName && 
                         book.Author.SurName == authorSurName);
        }

    
    }
}