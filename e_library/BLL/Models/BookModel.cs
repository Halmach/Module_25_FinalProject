using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.BLL.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYser { get; set; }
        public string AuthorSurName { get; internal set; }
        public string AuthorName { get; internal set; }
        public string Genre { get; internal set; }
    }
}
