using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string n_tomo = args[0];
            var caps = Directory.EnumerateDirectories(Directory.GetCurrentDirectory()).ToList();
            var d_tomo = Directory.CreateDirectory("Tomo 0" + n_tomo);
            for (int i = 1; i < caps.Count + 1; i++)
            {
                var files = Directory.EnumerateFiles(caps[i-1]);
                foreach (var file in files)
                {
                    var fileinfo = new FileInfo(file);
                    string fileName = fileinfo.Name;
                    if (fileinfo.Extension.ToLower() == ".jpg")
                    {
                        File.Copy(file,
                            Path.Combine(d_tomo.FullName, i + fileName));
                    }
                }
            }
        }
    }
}
