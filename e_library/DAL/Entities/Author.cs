using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
        // Навигационное свойство
        public Book AuthorBook { get; set; }

    }
}
