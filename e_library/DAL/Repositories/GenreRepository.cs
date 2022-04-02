using e_library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class GenreRepository:BaseRepository
    {
        // Добавление жанра в бд
        public bool AddNewGenre(Genre anyGenre)
        {
            try
            {
                db.Genres.Add(anyGenre);
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
