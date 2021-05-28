using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Photohosting.ViewModels
{
    class AllAccountsViewModel:BaseViewModel
    {
        public AllAccountsViewModel()
        {
            AllUsers = AccountsRepository.GetAccounts();
        }
        private ObservableCollection<Account> allUsers;
        public ObservableCollection<Account> AllUsers { 
            get {return allUsers; }
            set {
                allUsers = value;
                OnPropertyChanged(nameof(AllUsers)); } }


        #region Commands
        public ICommand DeleteCommand => new DelegateCommand<int>(DeleteElement,true);

        private void DeleteElement(int id)
        {
            AccountsRepository.Delete(id);
        }
        public ICommand SetAdminCommand => new DelegateCommand<int>(SetAdmin, true);

        private async void SetAdmin(int id)
        {
            Account acc=AccountsRepository.GetAccount(id);
            acc.IsAdmin = (!acc.IsAdmin);
            AccountsRepository.Update(acc);
            AllUsers = AccountsRepository.GetAccounts();
        }
        #endregion
    }
}
