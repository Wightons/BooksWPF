using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Models
{
    public class Save : BaseModel
    {
        public ICollection<Book> SavedBooks { get; set; }
        public User User { get; set; }
    }
}
