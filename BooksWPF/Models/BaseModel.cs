using System.ComponentModel.DataAnnotations;

namespace BooksWPF.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}