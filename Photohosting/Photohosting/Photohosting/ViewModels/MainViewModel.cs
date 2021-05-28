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
using System.Windows.Input;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Photohosting.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        

        public MainViewModel()
        {
            AllPictures = ListToObserv(PicturesRepository.GetPictures());
            SelectedViewModel = new AllPicturesViewModel(this);
        }


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
        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
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
        public string Top;
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
                SelectedViewModel = new AllPicturesViewModel(this, Top);
               OnPropertyChanged(nameof(Topic));
            }
        }
        public ObservableCollection<Picture> AllPictures { get; set; }
        public ObservableCollection<Picture> SearchResult { get; set; }
        #region Commands
        public ICommand OpenPicturePageCommand => new DelegateCommand(OpenPicturePage);

        private void OpenPicturePage()
        {
            this.SelectedViewModel = new PictureControlViewModel(AllPictures, Index, this);
        }

        public ICommand SearchCommand => new DelegateCommand<object>(Search);

        private void Search(object obj)
        {
            switch (obj)
            {
                case "Magnify":
                    if (SearchText != null)
                    {
                        SearchResult = new ObservableCollection<Picture>();
                        foreach (Picture pic in AllPictures)
                        {
                            if (ToString(pic).Contains(SearchText))
                            {
                                SearchResult.Add(pic);
                            }
                        }
                        if (SearchResult.Count() == 0)
                            ErrorMes = "No results";
                        SelectedViewModel = new AllPicturesViewModel(this, SearchResult);
                    }
                    break;
                case "WindowClose":
                    SearchText = "";
                    ErrorMes = "";
                    break;
                default:
                    break;
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

        public string ToString(Picture pic)
        {
            return pic.Name + " " + pic.Description;
        }
        #endregion




    }
}
