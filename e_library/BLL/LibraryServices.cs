using e_library.BLL.Models;
using e_library.DAL.Entities;
using e_library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.BLL
{
    public class LibraryServices
    {
        private UserRepository userRepository;
        private BookRepository bookRepository;
        private IssuedBookRepository issuedBookRepository;
        private GenreRepository genreRepository;
        private AuthorRepository authorRepository;

        public LibraryServices()
        {
            this.userRepository = new UserRepository();
            this.bookRepository = new BookRepository();
            this.issuedBookRepository = new IssuedBookRepository();
            this.genreRepository  = new GenreRepository();
            this.authorRepository = new AuthorRepository();
        }

        public bool AddUser(UserRegistrationData userRegistrationData)
        {
            var user = new User() { Name = userRegistrationData.Name, Email = userRegistrationData.Email};

            return userRepository.AddNewUser(user);
        }

        public bool AddBook(BookAdditionData bookAdditionData)
        {
            var anyBook = new Book() { 
                
                Title = bookAdditionData.Title, 
                Description = bookAdditionData.Description, 
                ReleaseYser = bookAdditionData.ReleaseYser,
                AuthorID = bookAdditionData.AuthorId,
                GenreId = bookAdditionData.GenreId
            };

            //anyBook.Author = authorRepository.GetAuthorByID(bookAdditionData.AuthorId);
            //anyBook.Genre = genreRepository.GetGenreByID(bookAdditionData.GenreId);

            return bookRepository.AddNewBook(anyBook);
        }

        public bool AddIssuedBook(int userID, int bookID)
        {
            var user = userRepository.SelectUserByID(userID);
            if (user == null) return false;

            var book = bookRepository.SelectBookByID(bookID);
            if (book == null) return false;

            var issuedBook = new IssuedBook() { BookID = book.ID, UserID = user.Id };
            user.Books.Add(issuedBook);

            return issuedBookRepository.AddIssuedEntry(issuedBook);    
        }

        public bool AddGenre(string genreName)
        {
            var genre = new Genre() { Name = genreName };

            return genreRepository.AddNewGenre(genre);
        }

        public bool AddAuthor(string authorSurName, string authorName)
        {
            var author = new Author() { SurName = authorSurName, Name = authorName};

            return authorRepository.AddNewAuthor(author);
        }

        public List<BookModel> GetBooksByGenreAndYears(string genre, int yearFrom, int yearTo)
        {
            var bookList = bookRepository.GetBooksByGenreAndYears(genre, yearFrom, yearTo);

            var result = bookList.Select(
                b => new BookModel { ID = b.ID, Title = b.Title, 
                Description = b.Description, ReleaseYser = b.ReleaseYser, 
                AuthorSurName = b.Author.SurName, AuthorName = b.Author.Name, Genre = b.Genre.Name });

            return result.ToList();
        }

        public  int GetCountOfBooksByAuthor(string surName, string name)
        {
            return bookRepository.GetCountOfBooksByAuthor(surName, name);
        }

        public int GetCountOfBooksByGenre(string genreName)
        {
            return bookRepository.GetCountOfBooksByGenre(genreName);
        }

        public bool GetFlagOfBookByAuthorAndTitle(string surName, string name, string bookTitle)
        {
            return bookRepository.GetFlagOfBookByAuthorAndTitle(surName, name, bookTitle);
        }
    }
}
