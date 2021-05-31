using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Runtime.Serialization;

namespace Photohosting.ViewModels
{
    class PictureControlViewModel:BaseViewModel
    {
        Picture picture = new Picture();
        BaseViewModel model;
        public PictureControlViewModel(ObservableCollection<Picture> AllPictures, int index, BaseViewModel model)
        {
            picture = AllPictures[index] ;
            this.SelectedViewModel = new AllPicturesViewModel(model,Topic);
            this.model = model;
            UsersPictures = GetItems();
            ContainsPicture();
        }
        public PictureControlViewModel()
        {
            this.SelectedViewModel = new AllPicturesViewModel(model,Topic);
            UsersPictures = GetItems();
            ContainsPicture();

        }

        #region Properties/Feilds
        public bool savePicture;
        public bool SavePicture
        {
            get
            {
                return savePicture;
            }
            set
            {
                savePicture = value;
                OnPropertyChanged(nameof(SavePicture));
            }
        }
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
        public string Name
        {
            get { return picture.Name; }
            set
            {
                picture.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Topic
        {
            get { return picture.MainTopic; }
            set
            {
                picture.MainTopic = value;
                OnPropertyChanged(nameof(Topic));
            }
        }
        public string Description
        {
            get { return picture.Description; }
            set
            {
                picture.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        ObservableCollection<Picture> UsersPictures { get; set; }
        private Visibility _commentsVisibility = Visibility.Visible;
        private Visibility _nocommentsVisibility = Visibility.Collapsed;
        public Visibility CommentsVisibility
        {
            get
            {
                return _commentsVisibility;
            }
            set
            {
                _commentsVisibility=value;
                OnPropertyChanged(nameof(CommentsVisibility));
            }
        }
        public Visibility NoCommentsVisibility
        {
            get
            {
                return _nocommentsVisibility;
            }
            set
            {
                _nocommentsVisibility = value;
                OnPropertyChanged(nameof(NoCommentsVisibility));
            }
        }
        #endregion

        #region Commands
        public ICommand SavePictureCommand => new DelegateCommand(SavePictureFunc,true);

        private async void SavePictureFunc()
        {
            try
            {
                if (SavePicture == true)
                {
                    UsersPictures.Add(picture);
                    SetItems(UsersPictures);
                }
                else
                {
                   
                    Del(picture);
                    SetItems(UsersPictures);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand CommentsCommand => new DelegateCommand(Comments, true);
        public void Comments()
        {
            if (CommentsVisibility==Visibility.Visible)
            {
                CommentsVisibility = Visibility.Collapsed;
                NoCommentsVisibility = Visibility.Visible;
                this.SelectedViewModel = new CommentsViewModel(picture.PID);
            }
            else
            {
                CommentsVisibility = Visibility.Visible;
                NoCommentsVisibility = Visibility.Collapsed;
                this.SelectedViewModel = new AllPicturesViewModel(model, Topic);
            }
        }
        #endregion

        #region Functions
        public ObservableCollection<Picture> GetItems()
        {
            ObservableCollection<Picture> pictures=new ObservableCollection<Picture>();
            try
            {
                DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(ObservableCollection<Picture>));
                using (FileStream f = new FileStream(@"..\..\Walls\" + Properties.Settings.Default.IdUser + ".json", FileMode.OpenOrCreate))
                {
                    pictures = (ObservableCollection<Picture>)jsonForm.ReadObject(f);
                }
            }
            catch(Exception ex)
            {
                return pictures;
                MessageBox.Show(ex.Message);
            }
            return pictures;
        }
        public void SetItems(ObservableCollection<Picture> pictures)
        {
           
            DataContractJsonSerializer jsonForm = new DataContractJsonSerializer(typeof(ObservableCollection<Picture>));

            using (FileStream fs = new FileStream(@"..\..\Walls\"+Properties.Settings.Default.IdUser + ".json", FileMode.OpenOrCreate))
            {
                jsonForm.WriteObject(fs, pictures);
               // MessageBox.Show("Data has been saved to file");
            }
        }
        public void ContainsPicture()
        {
            bool i=false;
            foreach (Picture pic in UsersPictures)
                if (pic.PID == this.picture.PID)
                    i= true;
            SavePicture = i;
        }
        public void Del(Picture pic)
        {
            ObservableCollection<Picture> list = new ObservableCollection<Picture>();
            foreach (Picture p in UsersPictures)
                if (p.PID != pic.PID) list.Add(p);
            UsersPictures.Clear();
            foreach (Picture p in list)
                 UsersPictures.Add(p);
        }
        #endregion
    }
}
