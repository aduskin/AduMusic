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

namespace AduMusic.Views
{
    /// <summary>
    /// MusicList.xaml 的交互逻辑
    /// </summary>
    public partial class MusicList : Page
    {
        public MusicList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Song> li_song = new List<Song>();
            for(int i = 0; i < 36; i++)
            {
                Song s = new Song();
                s.SongName = i+"没想到你是这样的播放器";
                s.SingerName = "冷主播";
                s.ZhuanName = "AduMusic";
                s.SongSize = "2MB";
                li_song.Add(s);
            }
            gridList.ItemsSource = li_song;
        }
    }
    public class Song
    {
        public string SingerName { get; set; }
        public string SongName { get; set; }
        public string ZhuanName { get; set; }
        public string SongSize { get; set; }
      public string cover { get; set; }
    }
}
