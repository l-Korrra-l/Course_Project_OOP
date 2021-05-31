using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Photohosting.Commands;
using Photohosting.Models;
using Photohosting.Views;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DevExpress.Mvvm;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Photohosting.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
 

        public MainWindowViewModel()
        {
            SelectedMenuCommand = new DelegateCommand<string>(OnSelectedMenuCommand, CanSelectedMenuCommand);
            LogOutCommand = new DelegateCommand<Window>(OnLogOut);
            SelectedViewModel = new MainViewModel();
        }
        public MainWindowViewModel(BaseViewModel model)
        {
            SelectedMenuCommand = new DelegateCommand<string>(OnSelectedMenuCommand, CanSelectedMenuCommand);
            LogOutCommand = new DelegateCommand<Window>(OnLogOut);
            SelectedViewModel = model;
        }
        #region Properties/Fields
        private WindowState _CurrentwindowState = WindowState.Normal;

        public WindowState CurrentWindowState
        {
            get { return _CurrentwindowState; }
            set { _CurrentwindowState = value; OnPropertyChanged(nameof(CurrentWindowState)); }
        }

        private Visibility _openMenuVisibility = Visibility.Visible;
        private Visibility _closeMenuVisibility = Visibility.Collapsed;

        public Visibility OpenMenuVisibility
        {
            get { return _openMenuVisibility; }
            set
            {
                _openMenuVisibility = value;
                OnPropertyChanged(nameof(OpenMenuVisibility));
            }
        }
        public Visibility CloseMenuVisibility
        {
            get { return _closeMenuVisibility; }
            set
            {
                _closeMenuVisibility = value;
                OnPropertyChanged(nameof(CloseMenuVisibility));
            }
        }
        private Visibility _noAdminVisibility;
        private Visibility _adminVisibility;
        public Visibility NoAdminVisibility
        {
            get {
                //if(AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).IsAdmin != true)
                   _noAdminVisibility = Visibility.Visible;
               // else _noAdminVisibility = Visibility.Collapsed;
                return _noAdminVisibility;
            }
            set
            {
                _noAdminVisibility = value;
                OnPropertyChanged(nameof(NoAdminVisibility));
            }
        }
        public Visibility AdminVisibility
        {
            get {

                if (AccountsRepository.GetAccount(Properties.Settings.Default.IdUser)?.IsAdmin == true)
                   _adminVisibility=Visibility.Visible;
                else _adminVisibility = Visibility.Collapsed;
                return _adminVisibility;
            }
            set
            {
                _adminVisibility = value;
                OnPropertyChanged(nameof(AdminVisibility));
            }
        }
        public byte[] BinImage
        {
            get
            {
                if (AccountsRepository.GetAccount(Properties.Settings.Default.IdUser) == null)
                    return File.ReadAllBytes(Properties.Settings.Default.DefUser);
                else
                    return AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Pic;
            }
            set
            {
                AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Pic = value;
                OnPropertyChanged(nameof(BinImage));
            }
        }
        #endregion

        #region Commands
        private RelayCommand minimizeCommand;
        public RelayCommand MinimizeCommand
        {
            get
            {
                return minimizeCommand ??
                    (minimizeCommand = new RelayCommand(obj =>
                    {
                        CurrentWindowState = WindowState.Minimized;
                    }));
            }
        }
        private RelayCommand maximizeCommand;
        public RelayCommand MaximizeCommand
        {
            get
            {
                return maximizeCommand ??
                    (maximizeCommand = new RelayCommand(obj =>
                    {
                        if (CurrentWindowState == WindowState.Maximized)
                            CurrentWindowState = WindowState.Normal;
                        else CurrentWindowState = WindowState.Maximized;
                    }));
            }
        }
        private RelayCommand openMenuCommand;
        public RelayCommand OpenMenuCommand
        {
            get
            {
                return openMenuCommand ??
                    (openMenuCommand = new RelayCommand(obj =>
                    {
                        OpenMenuVisibility = Visibility.Collapsed;
                        CloseMenuVisibility = Visibility.Visible;

                    }));
            }
        }
        private RelayCommand closeMenuCommand;
        public RelayCommand CloseMenuCommand
        {
            get
            {
                return closeMenuCommand ??
                    (closeMenuCommand = new RelayCommand(obj =>
                    {
                        OpenMenuVisibility = Visibility.Visible;
                        CloseMenuVisibility = Visibility.Collapsed;
                    }));
            }
        }


        #region Menu
        public DelegateCommand<string> SelectedMenuCommand { get; set; }
        private void OnSelectedMenuCommand(string parameter)
        {
            switch (parameter)
            {
                case "Home":
                    this.SelectedViewModel = new MainViewModel();
                    break;
                case "Account":
                   this.SelectedViewModel = new AccountViewModel();
                    break;
                case "Add":
                   this.SelectedViewModel = new AddPictureViewModel();
                    break;
                case "Contacts":
                    this.SelectedViewModel = new ContactsViewModel();
                    break;
                case "Errors":
                    this.SelectedViewModel = new ErrorsViewModel();
                    break;
                case "Profiles":
                    this.SelectedViewModel = new AllAccountsViewModel();
                    break;

                default:
                    break;
            }
        }
        private bool CanSelectedMenuCommand(string parameter)
        {
            return true;
        }
        #endregion
        #region LogOut
        public DelegateCommand<Window> LogOutCommand { get; set; }
        private void OnLogOut(Window window)
        {
            var authWindow = new AuthorizationWindow();
            authWindow.Show();
            SetCurrentUser(new Account());
            Properties.Settings.Default.IdUser = -1;
            if (window != null)
            {
                window.Close();
            }
            Application.Current.Windows[1].Close();
        }
        #endregion
        #endregion

        public void SetCurrentUser(Account acc)
        {
            acc.UID = -1;
            DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(Account));
            using (FileStream fs = new FileStream(@"..\..\Models\CurrentUser.json", FileMode.Create))
            {
                jsonForm.WriteObject(fs, acc);
            }
        }

    }
}
