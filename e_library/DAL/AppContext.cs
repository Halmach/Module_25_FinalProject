using e_library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Books
        public DbSet<Book> Books { get; set; }


        // Объекты таблицы IssuedBooks
        public DbSet<IssuedBook> IssuedBooks { get; set; }

        // Объекты таблицы Genre
        public DbSet<Genre> Genres { get; set; }

        // Объекты таблицы Author
        public DbSet<Author> Authors { get; set; }


        public AppContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =DESKTOP-45Q7VOT\SQLEXPRESS01;DataBase =E_LIBRARY;Trusted_Connection=True;TrustServerCertificate=true; ");
        }
    }
}
