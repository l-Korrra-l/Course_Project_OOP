using Photohosting.ViewModels;
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
    /// Логика взаимодействия для AllAccountsView.xaml
    /// </summary>
    public partial class AllAccountsView : UserControl
    {
        public AllAccountsView()
        {
            InitializeComponent();
            DataContext = new AllAccountsViewModel();
        }
    }

 
}
