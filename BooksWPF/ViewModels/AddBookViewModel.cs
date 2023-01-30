using BooksWPF.Core;
using BooksWPF.Data;
using BooksWPF.Models;
using BooksWPF.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BooksWPF.ViewModels
{
    public class AddBookViewModel : ViewModel
    {

        private EFGenericRepository<Book> _booksRepository;
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Vendor> Vendors { get; set; }

        private Book book;

        public Book Book
        {
            get { return book; }
            set { book = value; OnPropertyChanged(); }
        }

        public string FilePath { get; set; }

        private string validationMessage;

        public string ValidationMessage
        {
            get { return validationMessage; }
            set { validationMessage = value; OnPropertyChanged(); }
        }


        public ICommand GetListItemsCommand { get; set; }
        public ICommand AddBookCommand { get; set; }

        public List<Genre> SelectedGenres { get; set; }

        private void PopulateLists()
        {
            EFGenericRepository<Genre> GenresRepository = new EFGenericRepository<Genre>(new BooksDbContext());
            EFGenericRepository<Author> AuthorsRepository = new EFGenericRepository<Author>(new BooksDbContext());
            EFGenericRepository<Vendor> VendorsRepository = new EFGenericRepository<Vendor>(new BooksDbContext());
            

            Genres = GenresRepository.Get();
            Authors = AuthorsRepository.Get();
            Vendors = VendorsRepository.Get();
        }

        public AddBookViewModel()
        {
            Book = new Book();

            PopulateLists();
            GetListItemsCommand = new RelayCommand(items =>
            {
                IEnumerable list = items as IEnumerable;
                Book.Genres = list.OfType<Genre>().ToList();

            }, o => true);

            AddBookCommand = new RelayCommand(x =>
            {
                _booksRepository = new EFGenericRepository<Book>(new BooksDbContext());
                if (FilePath.StartsWith(@"https://"))
                {
                    Book.Photo = ImageToByteConverter.FromURL(FilePath);
                }
                else
                {
                    Book.Photo = ImageToByteConverter.FromFile(FilePath);
                }

                
                _booksRepository.Create(Book);

                ValidationMessage = "successfully added";

            }, o => true);
        }
    }
}
