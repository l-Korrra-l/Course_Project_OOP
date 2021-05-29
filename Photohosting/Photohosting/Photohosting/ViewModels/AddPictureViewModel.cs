using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data.Entity.Validation;

namespace Photohosting.ViewModels
{
    class AddPictureViewModel:BaseViewModel
    {
        public AddPictureViewModel()
        {

        }

        #region Properties/Fields
        Picture picture = new Picture();
        public byte[] BinImage
        {
            get
            {
                return picture.Pic;
            }
            set
            {
                picture.Pic = value;
                OnPropertyChanged(nameof(BinImage));
            }
        }

        ComboBoxItem topic;
        public ComboBoxItem Topic
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
                Top = topic.Content.ToString();
                OnPropertyChanged(nameof(Topic));
            }
        }

        public string Top
        {
            get
            {
                return picture.MainTopic;
            }
            set
            {
                picture.MainTopic = Convert.ToString(value);
                OnPropertyChanged(nameof(Top));
            }
        }
        public string Title
        {
            get
            {
                return picture.Name;
            }
            set
            {
                picture.Name = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Description
        {
            get
            {
                return picture.Description;
            }
            set
            {
                picture.Description = value;
                OnPropertyChanged(nameof(Description));
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
      //  private ResourceDictionary DialogDictionary = new ResourceDictionary() { Source = new Uri("pack://application:,,,/MaterialDesignThemes.MahApps;component/Themes/MaterialDesignTheme.MahApps.Dialogs.xaml") };
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
                    picture.PicFileName = FilePath;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

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

        public ICommand AddPictureCommand => new DelegateCommand(AddPicture, OnAddPicture);
        private void AddPicture()
        {

            try
            {
               // InputDialog();
                ErrorMes = "";
                if (picture.Name == String.Empty || picture.Name == null || picture.MainTopic == String.Empty || picture.MainTopic == null || picture.Description == null || picture.Description == String.Empty || picture.Pic == null)
                {
                    ErrorMes="Поле пустое";
                }
                else 
                {
                    PicturesRepository.AddPicture(picture);
                    MessageBox.Show("Опубликовано", "ok!");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    MessageBox.Show(
                        eve.Entry.Entity.GetType().Name);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show( ve.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ErrorMes = ex.Message;
            }
        }
        public bool OnAddPicture()
        {
            return true;
        }
        #endregion

        #region Functions 
        private void InputDialog()
        {
            var metroDialogSettings = new MetroDialogSettings
            {
                //CustomResourceDictionary = DialogDictionary,
                NegativeButtonText = "CANCEL"
            };

            DialogCoordinator.Instance.ShowInputAsync(this, "MahApps Dialog", "Using Material Design Themes", metroDialogSettings);
        }
        #endregion
    }
}
