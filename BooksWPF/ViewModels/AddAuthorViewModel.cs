using BooksWPF.Core;
using BooksWPF.Data;
using BooksWPF.Models;
using BooksWPF.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BooksWPF.ViewModels
{
    public class AddAuthorViewModel : ViewModel
    {
        public EFGenericRepository<Author> Authors { get; set; }
        public Author Author { get; set; }

        private string validationMessage;

        public string ValidationMessage
        {
            get { return validationMessage; }
            set { validationMessage = value; OnPropertyChanged(); }
        }


        public string FilePath { get; set; }


        public ICommand AddCommand { get; set; }

        public AddAuthorViewModel()
        {
            Author = new Author();

            Authors = new EFGenericRepository<Author>(new BooksDbContext());
            AddCommand = new RelayCommand(o =>
            {

                Author newAuthor = new Author
                {
                    FullName = Author.FullName,
                    Desc = Author.Desc
                };

                if (FilePath.StartsWith(@"https://"))
                {
                    newAuthor.Photo = ImageToByteConverter.FromURL(FilePath);
                }
                else
                {
                    newAuthor.Photo = ImageToByteConverter.FromFile(FilePath);
                }


                ValidationMessage = "successfully added";
                Authors.Create(newAuthor);

            }, o => true);
        }

    }
}
