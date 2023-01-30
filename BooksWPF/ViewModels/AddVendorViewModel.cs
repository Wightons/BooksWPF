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
    public class AddVendorViewModel : ViewModel
    {

		private Vendor vendor;

		public Vendor Vendor
		{
			get { return vendor; }
			set { vendor = value; OnPropertyChanged(); }
		}

		public string FilePath { get; set; }

		public ICommand AddCommand { get; set; }

		public AddVendorViewModel()
		{
			Vendor = new Vendor();

			AddCommand = new RelayCommand(o =>
			{
                if (FilePath.StartsWith(@"https://"))
                {
                    Vendor.Photo = ImageToByteConverter.FromURL(FilePath);
                }
                else
                {
                    Vendor.Photo = ImageToByteConverter.FromFile(FilePath);
                }

                EFGenericRepository<Vendor> _repos = new EFGenericRepository<Vendor>(new BooksDbContext());
                _repos.Create(Vendor);
            }, o => true);
           

        }

	}
}
