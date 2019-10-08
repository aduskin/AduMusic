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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AduMusic
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void Mini_Click(object sender, RoutedEventArgs e)
        {
            MiniWindow mw = new MiniWindow(this);
            mw.Show();
            this.Hide();

        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            WindowStateChange();
        }
        private void WindowStateChange()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            DropShadowEffect de = null;
            if (this.WindowState == WindowState.Normal)
            {
                de = new DropShadowEffect();
                this.BorderThickness = new Thickness(20);
                de.BlurRadius = 20;
                de.Opacity = .15;
                de.ShadowDepth = 0;
                this.Effect = de;
            }
            else
            {
                this.BorderThickness = new Thickness(5);
                this.Effect = null;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ImageRadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            mainFrame.Navigate(new Uri(radio.Tag.ToString(), UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserLogin ul = new UserLogin();
            ul.Show();
        }
    }
}
