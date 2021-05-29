using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        #region Commands
        public ICommand DeleteCommand => new DelegateCommand<int>(DeleteElement, true);

        private void DeleteElement(int id)
        {
            if ( ErrorsRepository.GetError(id)?.Solved == true)
                ErrorsRepository.Delete(id);
            ErrorMes="Проблема не была решена";

        }
        public ICommand SetSolvedCommand => new DelegateCommand<int>(SetSolved, true);

        private async void SetSolved(int id)
        {
            Error err = ErrorsRepository.GetError(id);
            if (err.Solved == true) err.Solved = false;
            else err.Solved = true;
            ErrorsRepository.Update(err);
            AllErrors = ErrorsRepository.GetErrors();
        }
        #endregion
    }
}
