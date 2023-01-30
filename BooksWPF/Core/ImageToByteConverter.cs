using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF.Core
{
    public static class ImageToByteConverter
    {

        public static byte[] FromURL(string path)
        {
            byte[] imageBytes;
            using (var webClient = new WebClient())
            {
                imageBytes = webClient.DownloadData(path);
            }
            return imageBytes;
        }


        public static byte[] FromFile(string path)
        {
            byte[] imageBytes = File.ReadAllBytes(path);
            return imageBytes;
        }
    }
}
