using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Photohosting.ViewModels
{
    class ErrorsViewModel:BaseViewModel
    {
        public ErrorsViewModel()
        {
            AllErrors = ErrorsRepository.GetErrors();
        }
        private ObservableCollection<Error> allErroros;
        public ObservableCollection<Error> AllErrors
        {
            get { return allErroros; }
            set
            {
                allErroros = value;
                OnPropertyChanged(nameof(AllErrors));
            }
        }


        #region Commands
        public ICommand DeleteCommand => new DelegateCommand<int>(DeleteElement, true);

        private void DeleteElement(int id)
        {
            ErrorsRepository.Delete(id);
        }
        public ICommand SetSolvedCommand => new DelegateCommand<int>(SetSolved, true);

        private async void SetSolved(int id)
        {
            Error err = ErrorsRepository.GetError(id);
            err.Solved = (!err.Solved);
            ErrorsRepository.Update(err);
            AllErrors = ErrorsRepository.GetErrors();
        }
        #endregion
    }
}
