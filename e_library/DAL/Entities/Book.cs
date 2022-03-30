using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYser { get; set; }

        // Навигационное свойство
        public IssuedBook IssuedBook { get; set; }
    }
}
