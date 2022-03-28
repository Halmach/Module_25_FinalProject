using e_library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class BookRepository : BaseRepository
    {
        // Вывести всех книг
        public List<Book> SelectAllBooks()
        {
            return db.Books.ToList();
        }

        // Выбор книги по id
        public Book SelectBookByID(string ID)
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
        public bool UpdateBookDateByID(string ID, int year)
        {
            var book = db.Books.Where(book => book.ID == ID).FirstOrDefault();

            if (book != null) book.ReleaseYser = year;
            else return false;

            db.SaveChanges();

            return true;
        }
    }
}
