using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photohosting.Models;
using Photohosting.Views;
using Photohosting.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Photohosting.ViewModels
{
    class RegisterViewModel : BaseViewModel
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

        private bool ValidatePassword(string password)
        {
            string pattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$"; //8-15 символов, минимум одно число, большая и маленькая буква
            if (Regex.IsMatch(password, pattern))
                return true;
            return false;
        }

        private bool Validate(object obj)
        {
            var passwordBox = obj as PasswordBox;
            string password = passwordBox.Password;
            if (password == null)
            {
                MessageBox.Show("Enter password");
                return false;
            }
            if (Login == null)
            {
                MessageBox.Show("Enter login");
                return false;
            }
            if (!ValidatePassword(password))
            {
                MessageBox.Show("Password must be between 8 and 15 characters, at least 1 number, upper and lowercase letters");
                return false;
            }
            return true;
        }
        private RelayCommand registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                    (registerCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            var passwordBox = obj as PasswordBox;
                            string password = passwordBox.Password;
                            password = AccountsRepository.HashPassword(password);
                            if (!AccountsRepository.ContainsAccount(Login, password) && !Validate(obj))
                            {

                                Account acc = new Account();
                                acc.Login = Login;
                                acc.Password = password;
                                acc.IsAdmin = 0;
                                AccountsRepository.AddAccount(acc);

                                App.Current.MainWindow.DataContext = new MainWindowViewModel(new MainViewModel());
                            }
                            else MessageBox.Show("No such account found");
                        }
                        catch(Exception e)
                        { }
                    }
                    )
                    );
            } 
            
        }
    }
}
