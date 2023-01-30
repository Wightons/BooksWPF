using BooksWPF.Core;
using BooksWPF.Services;

namespace BooksWPF.ViewModels
{
    public class MainViewModel : ViewModel
    {
		


		public MainViewModel(INavigationService nav)
		{
			Navigation = nav;
			Navigation.NavigateTo<LoginViewModel>();
        }



	}
}
