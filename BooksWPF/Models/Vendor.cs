using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Models
{
    public class Vendor : BaseModel
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public string Desc { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
