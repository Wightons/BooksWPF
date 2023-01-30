using BooksWPF.Core;
using BooksWPF.Data;
using BooksWPF.Models;
using BooksWPF.Repository;
using BooksWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BooksWPF.ViewModels
{

    public class LoginViewModel : ViewModel
    {
        private User user;

        public User User
        {
            get => user;
            set 
            { 
                user = value; 
                OnPropertyChanged();
            }
        }

        public EFGenericRepository<User> Users { get; set; }

        private string validationMessage;

        public string ValidationMessage
        {
            get => validationMessage;
            set 
            { 
                validationMessage = value;
                OnPropertyChanged();
            }
        }


        public ICommand GetPasswordCommand { get; set; }
        public ICommand NavigateToRegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(INavigationService nav)
        {
            User = new User();
            Users = new EFGenericRepository<User>(new BooksDbContext());

            LoginCommand = new RelayCommand(o =>
            {
                User getUser = Users.Get(u => u.Login == User.Login).FirstOrDefault();
                if (getUser != null)
                {
                    ValidationMessage = string.Empty;
                    if (getUser.Password == PasswordHash.CreateMD5(User.Password))
                    {
                        Navigation.CurrentView = new HomeViewModel(nav, getUser);
                    }
                    else
                        ValidationMessage = "Wrong Account Info";
                }
                else
                {
                    ValidationMessage = "No Such User";
                }
            },
            o=>true);
            GetPasswordCommand = new RelayCommand(o => 
            {
                var passwordBox = (PasswordBox)o;
                User.Password = passwordBox.Password;
            }, o => true);

            NavigateToRegisterCommand = new RelayCommand(o => { Navigation.NavigateTo<RegisterViewModel>(); }, o => true);
            Navigation = nav;
        }
    }
}
