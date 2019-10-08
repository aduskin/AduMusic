using AduMusic.Common;
using AduMusic.Styles.Carousel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace AduMusic.Views
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
         List<Song> list = new List<Song>();
         for (int i = 0; i < 8; i++)
         {
            Song s = new Song();
            s.SongName = i + "没想到你是这样的播放器";
            s.SingerName = "冷主播";
            s.cover = "https://qpic.y.qq.com/music_cover/bof4MDsSxjG6Va3xXJrNAGk5nDwflHw4er18BV1KARY3PsdBQlfupw/300?n=1";
            s.ZhuanName = "AduMusic";
            s.SongSize = "2MB";
            list.Add(s);
         }
         List<CarouselItem> ltFiles = new List<CarouselItem>();

         //List<string> ltFiles = FolderHelper.GetAllFileFullName(sPath);
         if (list.Count == 0)
         {
            MessageBox.Show("未查找到素材文件！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
         }
         else
         {
            for (int i = 0; i < list.Count; i++)
            {
               CarouselItem item = new CarouselItem();
               item.Name = list[i].SongName;
               item.Url = list[i].cover;
               ltFiles.Add(item);
            }
            this.Homes.Children.Clear();

            Carousel2DView view2D = new Carousel2DView(ltFiles);
            //view2D.Width = 800;
            //view2D.OnReturn += View_OnReturn;
            this.Homes.Children.Add(view2D);
            //Carousel3DView view3D = new Carousel3DView(ltFiles);
            //view2D.Width = 800;
            //view2D.OnReturn += View_OnReturn;
            //this.Home2.Children.Add(view3D);
            NewHot.ItemsSource = list;
         }

      }
        public void View_OnReturn()
        {
            this.Homes.Children.Clear();

            //CurNavPage = new NavPage();
            //CurNavPage.OnSelectChanged += PageNav_OnSelectChanged;
            //this.GdMain.Children.Add(CurNavPage);
        }
    }
}
