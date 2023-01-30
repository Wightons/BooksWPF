using BooksWPF.Core;
using BooksWPF.Models;
using BooksWPF.Services;
using System.Windows.Input;

namespace BooksWPF.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        
        public string AdminPanelVisibility { get; set; }
        public string ProfileName { get; set; }


        private INavigationService innerNavigation;

        public INavigationService InnerNavigation
        {
            get { return innerNavigation; }
            set { innerNavigation = value; OnPropertyChanged(); }
        }



        public ICommand CheckedCommand { get; set; }
        public ICommand LogoutCommand { get; set; }

        public HomeViewModel(INavigationService nav, User user)
        {
            InnerNavigation = new NavigationService(default);
            InnerNavigation.CurrentView = new BooksListViewModel();

            int tmp = user.Role;
            ProfileName = user.Login;

            if (tmp == 1)
                AdminPanelVisibility = "Hidden";
            else
                AdminPanelVisibility = "Visible";

            LogoutCommand = new RelayCommand(o => 
            {
                Navigation.NavigateTo<LoginViewModel>();
            }, 
            o => true);


            CheckedCommand = new RelayCommand(param =>
            {

                switch (param.ToString())
                {
                    case "Authors":
                        InnerNavigation.CurrentView = new AddAuthorViewModel();
                        break;
                    case "Books":
                        InnerNavigation.CurrentView = new AddBookViewModel();
                        break;
                    case "Genres":
                        InnerNavigation.CurrentView = new AddGenreViewModel();
                        break;
                    case "Vendors":
                        InnerNavigation.CurrentView = new AddVendorViewModel();
                        break;
                    default:
                        break;
                }

            },
            o => true);

            Navigation = nav;
        }

    }
}
