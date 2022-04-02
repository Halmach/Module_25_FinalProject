﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Entities
{
    public class Genre
    {   
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public Book Book { get; set; }
    }
}
