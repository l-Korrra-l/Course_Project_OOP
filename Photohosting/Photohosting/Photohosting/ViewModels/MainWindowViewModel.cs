using Photohosting.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Photohosting.ViewModels
{
    public class MainWindowViewModel :BaseViewModel
    {
      

        public MainWindowViewModel()
        {
            SelectedViewModel = new LoginViewModel();
        }

        public MainWindowViewModel(BaseViewModel d)
        {
            SelectedViewModel = d;
        }

        private RelayCommand registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                (registerCommand = new RelayCommand(obj =>
                {
                    SelectedViewModel = new RegisterViewModel();
                }));
            }
        }

        private WindowState _CurrentwindowState = WindowState.Normal;

        public WindowState CurrentWindowState
        {
            get { return _CurrentwindowState; }
            set { _CurrentwindowState = value; OnPropertyChanged(nameof(CurrentWindowState)); }
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
    }
}
