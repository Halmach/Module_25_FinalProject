﻿using e_library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class IssuedBookRepository : BaseRepository
    {
        // Вывести все выданные книги
        public List<IssuedBook> SelectAllIssuedBooks()
        {
            return db.IssuedBooks.ToList();
        }

        // Выдача книги пользователю
        public bool AddIssuedEntry(IssuedBook issuedBook)
        {
            try
            {
                db.IssuedBooks.Add(issuedBook);
            }
            catch (Exception)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }
    }
}
