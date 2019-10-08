using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace AduMusic.API
{
    public static class PrivateMethod
    {
        public static BitmapSource GetImage(string url)
        {
            return ChangeBitmapToBitmapSource(GetNetImage(url));
        }
        //根据网络获取一张图片
        public static System.Drawing.Bitmap GetNetImage(string url)
        {
            System.Drawing.Image Logo = null;
            System.Net.WebClient wb = new System.Net.WebClient();
            Stream stream = wb.OpenRead(url);
            //网址自己改吧
            Logo = System.Drawing.Image.FromStream(stream);
            stream.Dispose(); stream.Close(); wb.Dispose();
            return (System.Drawing.Bitmap)Logo;
        }
        /// <summary>
        /// 下载网络图片到本地
        /// </summary>
        /// <param name="url">网络路径</param>
        /// <param name="path">文件夹名</param>
        /// <returns></returns>
        public static void DownNetImage(string url)
        {
            string fname = Path.GetFileName(url);
            string DirectoryPath = Environment.CurrentDirectory + "\\FMBackground\\";
            string fileName = DirectoryPath + "xinli" + fname;
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            if (!File.Exists(fileName))
            {
                System.Net.WebClient wb = new System.Net.WebClient();
                Stream stream = wb.OpenRead(url);
                //网址自己改吧
                System.Drawing.Image Logo = System.Drawing.Image.FromStream(stream);
                stream.Dispose(); wb.Dispose();
                Logo.Save(fileName);
            }
        }
        //根据获取一张本地图片
        public static System.Drawing.Bitmap GetLocalImage(string url)
        {
            return null;
        }
        

        public static BitmapSource ChangeBitmapToBitmapSource(Bitmap bmp)
        {
            BitmapSource returnSource=null;
            App.DispatcherHelper.Invoke(new Action(() =>
            {
                try
                {
                    returnSource = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
                catch
                {
                }
            }));
            return returnSource;
        }

        /// <summary>
        /// 下图片。缓存
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="action"></param>
        //public static void DownImage(string name, string path, Action<string> action)
        //{
        //    Task.Factory.StartNew(() => {
        //        string DirectoryPath = HTTP.RunPath + "images\\";
        //        string ImagePath = HTTP.RunPath + "images\\" + name;

        //        if (!Directory.Exists(DirectoryPath))
        //        {
        //            Directory.CreateDirectory(DirectoryPath);
        //        }
        //        if (!File.Exists(ImagePath))
        //        {
        //            using (WebClient wb = new WebClient())
        //            {
        //                wb.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
        //                wb.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
        //                wb.Headers.Add("Cache-Control", "max-age=0");
        //                wb.Headers.Add("If-None-Match", "59cfaaac-56af");
        //                wb.Headers.Add("Host", "i.meizitu.net");
        //                wb.Headers.Add("Referer", "http://www.mzitu.com/");
        //                wb.DownloadFile(path, ImagePath);
        //            }
        //        }
        //        action(ImagePath);
        //    });
        //}

        public static void DownImage(string DirectoryName, string Url)
        {
            //Task.Factory.StartNew(() => {
            //存储路径
            string DirectoryPath = System.Environment.CurrentDirectory + "\\FMBackground" + DirectoryName;

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            if (!File.Exists(DirectoryPath))
            {
                using (WebClient wb = new WebClient())
                {
                    wb.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
                    wb.Headers.Add("Accept-Encoding", "gzip, deflate");
                    wb.Headers.Add("Cache-Control", "max-age=0");
                    wb.Headers.Add("If-None-Match", "53675C2E11C46B5C2AE17B5CC79E4D7F");

                    wb.Headers.Add("If-Modified-Since", "Mon, 15 Aug 2016 10:11:21 GMT");
                    wb.Headers.Add("Upgrade-Insecure-Requests", "1");

                    wb.Headers.Add("Host", "image.xinli001.com");
                    wb.Headers.Add("Connection", "keep-alive");
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.75 Mobile Safari/537.36");
                    wb.Headers.Add("Referer", "http://fm.xinli001.com/");
                    wb.DownloadFile(Url, DirectoryPath);
                }
            }
            //});
        }
    }
}
