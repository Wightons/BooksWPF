using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Models
{
    public class Genre : BaseModel
    {
        public string GenreName { get; set; }


        public ICollection<Book> Books { get; set; }
    }
}
