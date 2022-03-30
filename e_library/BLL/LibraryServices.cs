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
        private IssuedBookRepository IssuedBookRepository;

        public LibraryServices()
        {
            this.userRepository = new UserRepository();
            this.bookRepository = new BookRepository();
            this.IssuedBookRepository = new IssuedBookRepository();
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

            return IssuedBookRepository.AddIssuedEntry(issuedBook);    
        }
    }
}
