using BooksWPF.Core;
using BooksWPF.Data;
using BooksWPF.Models;
using BooksWPF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksWPF.ViewModels
{
    public class BooksListViewModel : ViewModel
    {

        public IEnumerable<Book> Books { get; set; }

        public ICommand BookSelectionCommand { get; set; }

        private void PopulateList()
        {
            EFGenericRepository<Book> _repos = new EFGenericRepository<Book>(new BooksDbContext());
            Books = _repos.Get();
        }

        public BooksListViewModel()
        {
            PopulateList();

            BookSelectionCommand = new RelayCommand(o =>
            {

            }, o => true);

        }


    }
}
