using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Entities
{
    public class User
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Навигационное свойство
        public List<IssuedBook> Books { get; set; } = new List<IssuedBook>();
    }
}
