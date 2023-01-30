using BooksWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Repository
{
    public interface IGenericRepository<TModel> where TModel : BaseModel
    {
        void Create(TModel item);
        TModel FindById(int id);
        IEnumerable<TModel> Get();
        IEnumerable<TModel> Get(Func<TModel, bool> predicate);
        void Remove(TModel item);
        void Update(TModel item);
    }
}
