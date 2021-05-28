using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photohosting.Views;
using Photohosting.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using DevExpress.Mvvm;

namespace Photohosting.ViewModels
{
    class AllPicturesViewModel:BaseViewModel
    {
        public AllPicturesViewModel()
        {
            AllPictures = ListToObserv(PicturesRepository.GetPictures());
        }
        public AllPicturesViewModel(BaseViewModel model)
        {
            AllPictures = ListToObserv(PicturesRepository.GetPictures());
            this.model = model;
        }
        public AllPicturesViewModel(BaseViewModel model, ObservableCollection<Picture> pictures)
        {
            AllPictures = pictures;
            this.model = model;
        }
        public AllPicturesViewModel(BaseViewModel model,string topic)
        {
            if (topic=="All")
                AllPictures = ListToObserv(PicturesRepository.GetPictures());
            else
                AllPictures = ListToObserv(PicturesRepository.GetPicturesTopic(topic));
            this.model = model;
        }
        #region Properties/Fields
        public ObservableCollection<Picture> AllPictures { get; set; }
        public BaseViewModel model;
        private int index;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                this.index = value;
                OnPropertyChanged(nameof(Index));
            }
        }
        #endregion

        #region Commands
        public ICommand OpenPicturePageCommand => new DelegateCommand(OpenPicturePage);

        private void OpenPicturePage()
        {
            try
            {
                model.SelectedViewModel = new PictureControlViewModel(AllPictures, Index, model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Functions
        public ObservableCollection<Picture> ListToObserv(List<Picture> list)
        {
            ObservableCollection<Picture> res = new ObservableCollection<Picture>();
            if (list != null)
            {
                foreach (Picture a in list)
                    res.Add(a);
            }
            return res;
        }
        #endregion
    }
}
