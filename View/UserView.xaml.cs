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
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// UserView.xaml 的交互逻辑
    /// </summary>
    public partial class UserView : Window
    {
        public UserView(Persons per)
        {
            InitializeComponent();
            //Name.Focus();
            this.DataContext = new
            {
                Model = per
            };
            
        }



        private void BtnCannel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnConfirm(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
