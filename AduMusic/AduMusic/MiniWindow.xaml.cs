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

namespace AduMusic
{
    /// <summary>
    /// MiniWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MiniWindow : Window
    {
        MainWindow mw = null;
        public MiniWindow(MainWindow mws)
        {
            mw = mws;
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mw.Show();
            this.Close();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMax.Visibility = Visibility;
            btnClose.Visibility = Visibility;
            btnUp.Visibility = Visibility;
            btnPlay.Visibility = Visibility;
            btnNext.Visibility = Visibility;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMax.Visibility =Visibility.Collapsed;
            btnClose.Visibility = Visibility.Collapsed;
            btnUp.Visibility = Visibility.Collapsed;
            btnPlay.Visibility = Visibility.Collapsed;
            btnNext.Visibility = Visibility.Collapsed;
        }
    }
}
