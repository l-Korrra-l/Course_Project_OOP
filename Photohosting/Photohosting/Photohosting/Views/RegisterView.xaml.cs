﻿using Photohosting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Photohosting.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        RegisterViewModel a = new RegisterViewModel();
        public RegisterView()
        {
            InitializeComponent();
            DataContext = a;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            a.Password = PassBox.Password;
        }
    }
}
