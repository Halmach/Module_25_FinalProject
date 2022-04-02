using e_library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class AuthorRepository : BaseRepository
    {
        // Добавление автора в бд
        public bool AddNewAuthor(Author author)
        {
            try
            {
                db.Authors.Add(author);
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
