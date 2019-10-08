using AduMusic.API;
using AduMusic.Common;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AduMusic.Styles.Carousel
{
    /// <summary>
    /// ImageItem.xaml 的交互逻辑
    /// </summary>
    public partial class ImageItem : UserControl
    {
        public ImageItem(CarouselItem item)
        {
            InitializeComponent();
            this.FileSrc = item.Url;
            string sFileName = item.Name;
            this.TbkTitle.Text = sFileName;
            this.Loaded += ImageItem_Loaded;
            this.DataContext = this;
        }
        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(ImageItem), new UIPropertyMetadata(0.0));

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(ImageItem), new UIPropertyMetadata(0.0));

        public double ScaleX
        {
            get { return (double)GetValue(ScaleXProperty); }
            set { SetValue(ScaleXProperty, value); }
        }
        public static readonly DependencyProperty ScaleXProperty =
            DependencyProperty.Register("ScaleX", typeof(double), typeof(ImageItem), new UIPropertyMetadata(1.0));

        public double ScaleY
        {
            get { return (double)GetValue(ScaleYProperty); }
            set { SetValue(ScaleYProperty, value); }
        }
        public static readonly DependencyProperty ScaleYProperty =
            DependencyProperty.Register("ScaleY", typeof(double), typeof(ImageItem), new UIPropertyMetadata(1.0));

        public double Degree;
        private string FileSrc="";

        private bool _IsVisible = false;
        public new bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                if (value)
                    this.LoadUiImmediate();
            }
        }

        private bool IsUiLoaded = false;

        public void LoadUiImmediate()
        {
            if (!IsUiLoaded)
            {
                IsUiLoaded = true;
                try {
                    this.ImgMain.Source = PrivateMethod.GetImage(FileSrc);
                } catch { }
            }
        }

        

        private void ImageItem_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ImageItem_Loaded;
            AsynchUtils.AsynchSleepExecuteFunc(this.Dispatcher, LoadUiImmediate, 0.5);
        }

        public void Dispose()
        {
            this.ImgMain.Source = null;
        }
    }

    public class CarouselItem
    {
        //图片地址
        public string Url { get; set; }
        //名称
        public string Name { get; set; }
    }
}
