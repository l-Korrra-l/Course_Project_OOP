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
using System.Runtime.Serialization.Json;
using System.IO;

namespace Photohosting.ViewModels
{
    class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {
        }

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
        private string errorMes;
        public string ErrorMes
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                OnPropertyChanged(nameof(ErrorMes));
            }
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
                                Account acc = AccountsRepository.GetAccount(Login, password) ?? AccountsRepository.GetAccount(Login, password);
                                SetCurrentUser(acc);
                                Properties.Settings.Default.IdUser = AccountsRepository.GetAccount(Login).UID;
                                MainWindow _wind = new MainWindow();
                                _wind.Show();
                                AuthorizationWindowViewModel.Close();

                            }
                            else ErrorMes = "Аккаунт не найден";
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    )
                    );
            }

        }

        public void SetCurrentUser(Account acc)
        {
            DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Account));
            using (FileStream fs = new FileStream(@"..\..\Models\CurrentUser.json", FileMode.OpenOrCreate))
            {
                jsonForm.WriteObject(fs, acc);
            }
        }
    }
}
