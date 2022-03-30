using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Entities
{
    public class IssuedBook
    {
        public int Id { get; set; }

        // Внешний ключ
        public int UserID { get; set; }

        // Навигационное свойство
        public User User { get; set; }

        // Внешний ключ
        public int BookID { get; set; }

        // Навигационное свойство
        public Book Book { get; set; }
    }
}
