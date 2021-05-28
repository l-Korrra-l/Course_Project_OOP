using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Photohosting.ViewModels
{
    class CommentsViewModel:BaseViewModel
    {
        int PId;
        public CommentsViewModel(int id)
        {
            AllComments = CommentsRepository.GetComments(id);
            PId = id;
        }
        private ObservableCollection<Comment> allComments;
        public ObservableCollection<Comment> AllComments
        {
            get { return allComments; }
            set
            {
                Set();
                allComments = value;
                OnPropertyChanged(nameof(AllComments));
            }
        }
        public byte[] BinImage
        {
            get
            {
                if (Properties.Settings.Default.IdUser == null)
                    return File.ReadAllBytes(Properties.Settings.Default.DefUser);
                else
                    return AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Pic;
            }
            set
            {
                AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Pic = value;
                OnPropertyChanged(nameof(BinImage));
            }
        }
        public void Set()
        {
            if(AllComments!=null)
            foreach(Comment com in AllComments)
            {
                if (com.UPic == null)
                    com.UPic = File.ReadAllBytes(Properties.Settings.Default.DefUser);
                if (com.UName == null || com.UName == "")
                    com.UName = "Кто-то";
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public ICommand LeaveCommentCommand => new DelegateCommand(LeaveComment, true);
        public void LeaveComment()
        {
            if (Comment != null)
            {
                Comment com = new Comment();
                com.Date =DateTime.Now;
                com.PId = PId;
                com.Message = Comment;
                com.UId = Properties.Settings.Default.IdUser;
                com.UName = AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Name ?? "Кто-то";
                com.UPic = AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Pic ?? File.ReadAllBytes(Properties.Settings.Default.DefUser);
                CommentsRepository.AddComment(com);
                Comment = "";
                AllComments = CommentsRepository.GetComments(PId);
            }
            else MessageBox.Show("Пустое сообщение не было добавлено");
        }
    }
}
