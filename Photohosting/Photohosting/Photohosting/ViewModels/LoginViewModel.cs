using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Photohosting.Commands;
using System.Windows;
using System.Windows.Controls;
using Photohosting.Models;
using Photohosting.Views;

namespace Photohosting.ViewModels
{
    class LoginViewModel : BaseViewModel
    {


        private string login = "";
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public LoginViewModel()
        {
        }

        private RelayCommand registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                (registerCommand = new RelayCommand(obj =>
                {
                   App.Current.MainWindow.DataContext = new MainWindowViewModel(new RegisterViewModel());
                }));
            }
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ??
                    (loginCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            var passwordBox = obj as PasswordBox;
                            string password = passwordBox.Password;
                            password = AccountsRepository.HashPassword(password);
                            if (AccountsRepository.ContainsAccount(Login, password))
                            {

                                App.Current.MainWindow.DataContext = new MainWindowViewModel(new MainViewModel(AccountsRepository.GetAccount(Login)));
                            }
                            else MessageBox.Show("No such account found");
                        }
                        catch (Exception e)
                        { }
                    }
                    )
                    );
            }

        }
    }
}
