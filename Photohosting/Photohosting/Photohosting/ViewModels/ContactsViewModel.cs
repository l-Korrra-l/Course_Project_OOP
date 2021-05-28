using DevExpress.Mvvm;
using Photohosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Photohosting.ViewModels
{
    class ContactsViewModel: BaseViewModel
    {
        public ContactsViewModel()
        {
        }

        #region Commands
        public DelegateCommand ContactCommand => new DelegateCommand(OnContactCommand, CanContactCommand);
        private void OnContactCommand()
        {
            if (PasswordVisibility == Visibility.Visible)
                PasswordVisibility = Visibility.Collapsed;
            if (MailVisibility == Visibility.Visible)
                MailVisibility = Visibility.Collapsed;
            if (Message == "")
                MessageBox.Show("Enter message");
            else
            try
            {
                Error err = new Error();
                if (AccountsRepository.GetAccount(Properties.Settings.Default.IdUser) != null)
                    err.Message = AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Name + ": ";
                else err.Message = "Unknown user: ";
                err.Message += Message;
                err.Solved = false;
                ErrorsRepository.AddError(err);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, try again.");
            }

        }
        private bool CanContactCommand()
        {
            return true;
        }
        public DelegateCommand<object> MailCommand => new DelegateCommand(OnMailCommand, true);
        private void OnMailCommand()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("courseprphotohosting@gmail.com");
                mail.To.Add(new MailAddress("korrra.mergel@gmail.com"));
                mail.To.Add(new MailAddress("courseprphotohosting@gmail.com"));
                mail.Subject = "Photohosting app";
                mail.Body ="<h2>From user :"+AccountsRepository.GetAccount(Properties.Settings.Default.IdUser).Name + "</h2></br>"+Message;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("courseprphotohosting@gmail.com", "12345678!q");
                smtp.EnableSsl = true;
                mail.IsBodyHtml = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, try again. It seems that your account security has blocked the operation");
            }

        }
        private bool CanMailCommand(object obj)
        {
            return true;
        }
        #endregion

        #region Properties/Feileds
        private string message = "";
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        private string mail = "";
        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }

        private Visibility mailVisibility = Visibility.Collapsed;

        public Visibility MailVisibility
        {
            get { return mailVisibility; }
            set
            {
                mailVisibility = value;
                OnPropertyChanged("MailVisibility");
            }
        }

        private Visibility passwordVisibility = Visibility.Collapsed;

        public Visibility PasswordVisibility
        {
            get { return passwordVisibility; }
            set
            {
                passwordVisibility = value;
                OnPropertyChanged("PasswordVisibility");
            }
        }
        #endregion
        public bool ValidateMail()
        {
            try
            {
                MailAddress mail = new MailAddress(Mail);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid mail");
                Mail = "";
                return false;
            }
        }
        public bool Valid(string pass)
        {
            if (Mail==null)
            {
                MessageBox.Show("Enter mail");
                return false;
            }
            if (pass==null || pass=="")
            {
                MessageBox.Show("Enter password");
                return false;
            }
            if (Message==null)
            {
                MessageBox.Show("Enter message");
                Message = "";
                return false;
            }
            return ValidateMail();
        }
    }
}
