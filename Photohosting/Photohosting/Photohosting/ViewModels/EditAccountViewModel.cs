using DevExpress.Mvvm;
using Photohosting.Models;
using Photohosting.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Photohosting.ViewModels
{
    class EditAccountViewModel:BaseViewModel
    {
        public EditAccountViewModel()
        { }
        public EditAccountViewModel(Window window)
        {
            window1 = window;
        }
        Account account = AccountsRepository.GetAccount(Properties.Settings.Default.IdUser);
        #region Properties/Fields
        public string Name
        {
            get { return  account.Name; }
            set
            {
                account.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string LName
        {
            get { return account.LastName; }
            set
            {
                account.LastName = value;
                OnPropertyChanged("LName");
            }
        }
        public string Mail
        {
            get { return account.Email; }
            set
            {
                account.Email = value;
                OnPropertyChanged("Mail");
            }
        }
        public int Phone
        {
            get { return (int)account.Phone_Number; }
            set
            {
                account.Phone_Number = value;
                OnPropertyChanged("Phone");
            }
        }
        public DateTime Bday
        {
            get { return (DateTime)account.BdayDate; }
            set
            {
                account.BdayDate = value;
                OnPropertyChanged("Bday");
            }
        }
        Window window1;
        public byte[] BinImage
        {
            get
            {
                if (account.Pic == null)
                    return File.ReadAllBytes(Properties.Settings.Default.DefUser);
                else
                    return account.Pic;
            }
            set
            {
                account.Pic = value;
                OnPropertyChanged(nameof(BinImage));
            }
        }
        #endregion

        #region Commands
        public ICommand OpenImageCommand => new DelegateCommand(OpenImage);
        private void OpenImage()
        {
            string FilePath = "";
            if (OpenFile(ref FilePath))
            {
                try
                {
                    this.BinImage = File.ReadAllBytes(FilePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public ICommand EditProfileCommand => new DelegateCommand(EditProfile);
        private void EditProfile()
        {
            try
            {
                AccountsRepository.Update(account);
                foreach (Window window in App.Current.Windows)
                {
                    (window as MainWindow).DataContext = new MainWindowViewModel(new AccountViewModel(new AllPicturesViewModel()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region Functions
        private bool OpenFile(ref string FilePath)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
        #endregion
    }
}
