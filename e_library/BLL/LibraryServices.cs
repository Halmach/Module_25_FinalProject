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
                ReleaseYser = bookAdditionData.ReleaseYser
            };

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
    }
}
