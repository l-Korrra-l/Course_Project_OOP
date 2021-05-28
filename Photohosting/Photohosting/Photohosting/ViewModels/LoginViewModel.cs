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
        private string password = "";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public LoginViewModel()
        {
        }

        public void CloseLoginWindow() => CloseWindow();

        private RelayCommand loginCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return loginCommand ??
                    (loginCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            //var passwordBox = obj as PasswordBox;
                            //string password = passwordBox.Password;
                            string password = AccountsRepository.HashPassword(Password);
                            if (AccountsRepository.ContainsAccount(Login, password) || AccountsRepository.ContainsAccount(Login, Password))
                            {
                                Properties.Settings.Default.IdUser = AccountsRepository.GetAccount(Login).UID;
                                MainWindow _wind = new MainWindow();
                                _wind.Show();
                                AuthorizationWindowViewModel.Close();

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
