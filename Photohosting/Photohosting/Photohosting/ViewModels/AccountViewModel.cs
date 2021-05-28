using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Net.Mail;

namespace Photohosting.ViewModels
{
    class AccountViewModel:BaseViewModel
    {
        public AccountViewModel()
        {
            this.SelectedViewModel = new AllPicturesViewModel(this, GetItems());

        }
        public AccountViewModel(BaseViewModel model)
        {
            this.SelectedViewModel = model;
        }

        Account account = AccountsRepository.GetAccount(Properties.Settings.Default.IdUser);
        #region Properties/Fields
        public string Name
        {
            get { return account.Name; }
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
            get { 
                return account.Email; }
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
        public byte[] BinImage
        {
            get
            {
                if (account == null)
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

        private Visibility _editVisibility = Visibility.Visible;
        private Visibility _uneditVisibility = Visibility.Collapsed;
        public Visibility EditVisibility
        {
            get { return _editVisibility; }
            set
            {
                _editVisibility = value;
                OnPropertyChanged(nameof(EditVisibility));
            }
        }
        public Visibility UnEditVisibility
        {
            get { return _uneditVisibility; }
            set
            {
                _uneditVisibility = value;
                OnPropertyChanged(nameof(UnEditVisibility));
            }
        }
        #endregion

        #region Commands

        public ICommand EditCommand => new DelegateCommand(Edit,true);
        private void Edit()
        {
            if (EditVisibility == Visibility.Visible)
            {
                EditVisibility = Visibility.Collapsed;
                UnEditVisibility = Visibility.Visible;
                account = AccountsRepository.GetAccount(Properties.Settings.Default.IdUser);
            }
            else
            {
                EditVisibility = Visibility.Visible;
                UnEditVisibility = Visibility.Collapsed;
            }

        }
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
                if (Validate())
                {
                    AccountsRepository.Update(account);
                    Edit();
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
        public ObservableCollection<Picture> GetItems()
        {
            ObservableCollection<Picture> pictures = new ObservableCollection<Picture>();
            try
            {
                DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(ObservableCollection<Picture>));
                using (FileStream f = new FileStream(@"..\..\Walls\" + Properties.Settings.Default.IdUser + ".json", FileMode.OpenOrCreate))
                {
                    pictures = (ObservableCollection<Picture>)jsonForm.ReadObject(f);
                }
            }
            catch (Exception ex)
            {
                return pictures;
                MessageBox.Show(ex.Message);
            }
            return pictures;
        }
        public bool Validate()
        {
            try
            {
                MailAddress mailAddress = new MailAddress(account.Email);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid mail");
                return false;
            }
        }
        #endregion
    }

}
