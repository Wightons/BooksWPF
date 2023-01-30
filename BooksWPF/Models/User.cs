using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Models
{
    public class User : BaseModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; } //1 - User; 2 - Admin

        public Save Save { get; set; }
        public int SaveId { get; set; }
    }
}
