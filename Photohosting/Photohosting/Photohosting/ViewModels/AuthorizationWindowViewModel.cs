using Photohosting.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Photohosting.ViewModels
{
    public class AuthorizationWindowViewModel :BaseViewModel
    {
      

        public AuthorizationWindowViewModel()
        {
            SelectedViewModel = new LoginViewModel();
        }

        public AuthorizationWindowViewModel(BaseViewModel d)
        {
            SelectedViewModel = d;
        }

        #region Commands
        private RelayCommand toregisterCommand;
        public RelayCommand ToRegisterCommand
        {
            get
            {
                return toregisterCommand ??
                (toregisterCommand = new RelayCommand(obj =>
                {
                    ToRegistrationVisibility = Visibility.Collapsed;
                    ToLoginVisibility = Visibility.Visible;
                    SelectedViewModel = new LoginViewModel();
                }));
            }
        }

        private RelayCommand tologinCommand;
        public RelayCommand ToLoginCommand
        {
            get
            {
                return tologinCommand ??
                (tologinCommand = new RelayCommand(obj =>
                {
                    ToRegistrationVisibility = Visibility.Visible;
                    ToLoginVisibility = Visibility.Collapsed;
                    SelectedViewModel = new RegisterViewModel();
                }));
            }
        }

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

        #endregion






        #region Fields/Properties        
        private WindowState _CurrentwindowState = WindowState.Normal;

        public WindowState CurrentWindowState
        {
            get { return _CurrentwindowState; }
            set { _CurrentwindowState = value; OnPropertyChanged(nameof(CurrentWindowState)); }
        }
        #region Visibility
        private Visibility _isToRegistrationVisible = Visibility.Collapsed;
        private Visibility _isToLoginVisible = Visibility.Visible;

        public Visibility ToRegistrationVisibility
        {
            get { return _isToRegistrationVisible; }
            set
            {
                _isToRegistrationVisible = value;
                OnPropertyChanged(nameof(ToRegistrationVisibility));
            }
        }
        public Visibility ToLoginVisibility
        {
            get { return _isToLoginVisible; }
            set
            {
                _isToLoginVisible = value;
                OnPropertyChanged(nameof(ToLoginVisibility));
            }
        }
        #endregion

        #endregion
        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
    }
}
