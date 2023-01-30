using BooksWPF.Core;
using BooksWPF.Data;
using BooksWPF.Models;
using BooksWPF.Repository;
using BooksWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BooksWPF.ViewModels
{
    public class RegisterViewModel : ViewModel
    {

        public EFGenericRepository<User> Users { get; set; }

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

        private string confirmPassword;

        public string ConfirmPassword
        {
            get => confirmPassword;
            set 
            { 
                confirmPassword = value; 
                OnPropertyChanged();
            }
        }

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


        public ICommand NavigateToLoginCommand { get; set; }
        public ICommand GetPasswordCommand { get; set; }
        public ICommand GetConfirmPasswordCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public RegisterViewModel(INavigationService nav)
        {
            User = new User();
            Users = new EFGenericRepository<User>(new BooksDbContext());
            GetPasswordCommand = new RelayCommand(o =>
            {
                var passwordBox = (PasswordBox)o;
                User.Password = passwordBox.Password;
            },o=>true);

            GetConfirmPasswordCommand = new RelayCommand(o =>
            {
                var passwordBox = (PasswordBox)o;
                ConfirmPassword = passwordBox.Password;
            }, o => true);

            RegisterCommand = new RelayCommand(o =>
            {
                if (User.Password != ConfirmPassword)
                {
                    ValidationMessage = "Password not match";
                }
                else
                {
                    if (Users.Get(u=>u.Login == User.Login).FirstOrDefault() == null)
                    {
                        EFGenericRepository<Save> Saves = new EFGenericRepository<Save>(new BooksDbContext());
                        Saves.Create(new Save());
                        User newUser = new User { Login = User.Login, Password = PasswordHash.CreateMD5(User.Password), Role = 1, SaveId = Saves.Get().LastOrDefault().Id};

                        Users.Create(newUser);
                        ValidationMessage = "Succesfully Created";
                    }
                    else
                    {
                        ValidationMessage = "Login Already Exists";
                    }
                }
            }, o => true);

            NavigateToLoginCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>(); }, o => true);
            Navigation = nav;
        }
    }
}
