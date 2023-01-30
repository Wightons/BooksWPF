using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public Author Author { get; set; }
        public Vendor Vendor { get; set; }

        public ICollection<Save> Saves { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
