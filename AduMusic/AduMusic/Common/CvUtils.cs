using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AduMusic.Common
{
    public class CvUtils
    {
        public static Random GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return new Random(BitConverter.ToInt32(bytes, 0));
        }

        public static bool IsImageType(string file)
        {
            //格式为jpg、png和bmp
            return file.ToLower().EndsWith(".jpg") ||
                   file.ToLower().EndsWith(".jpeg") ||
                   file.ToLower().EndsWith(".png") ||
                   file.ToLower().EndsWith(".bmp") ||
                   file.ToLower().EndsWith(".gif") ||
                   file.ToLower().EndsWith(".tiff");
        }

        public static double ConvertToRads(double dDegree)
        {
            return dDegree * Math.PI / 180.0;
        }

        public static SolidColorBrush Convert16ToSolidColor(string value)
        {
            string val = value.ToString();
            val = val.Replace("#", "");
            byte a = Convert.ToByte("ff", 16);
            byte pos = 0;
            if (val.Length == 8)
            {
                a = Convert.ToByte(val.Substring(pos, 2), 16);
                pos = 2;
            }
            byte r = Convert.ToByte(val.Substring(pos, 2), 16);
            pos += 2;
            byte g = Convert.ToByte(val.Substring(pos, 2), 16);
            pos += 2;
            byte b = Convert.ToByte(val.Substring(pos, 2), 16);
            Color col = Color.FromArgb(a, r, g, b);
            return new SolidColorBrush(col);
        }
    }
}
