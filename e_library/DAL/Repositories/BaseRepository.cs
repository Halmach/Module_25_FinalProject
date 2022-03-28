using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class BaseRepository
    {   
        protected AppContext db = new AppContext();
    }
}
