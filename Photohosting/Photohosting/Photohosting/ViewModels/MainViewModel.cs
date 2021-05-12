using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Photohosting.Views;
using Photohosting.Models;
using System.Runtime.CompilerServices;
using System.Windows;
using Photohosting.Commands;

namespace Photohosting.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        
        public Account CurrentAccount;
        private MainWindow window;
        private Account user;

        
        private bool adminVisibility = false;
        private Account account;

        public bool AdminVisibility
        {
            get { return adminVisibility; }
            set
            {
                adminVisibility = value;
                OnPropertyChanged("AdminVisibility");
            }
        }

        public MainViewModel()
        {
        }

        public MainViewModel(Account account)
        {
            this.account = account;
        }

 





    }
}
