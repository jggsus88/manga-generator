using System;
using System.IO;
using System.Linq;

namespace MangaGenerator
{
    class Program
    {
        private static readonly string[] acceptedFormats = new string [] { ".jpg", ".jpeg", ".png" }; 

        static void Main(string[] args)
        {
            Console.WriteLine("Write the number of the volume");
            string n_tomo = Console.ReadLine();
            Console.WriteLine("Write the path of the chapters directory (empty if you want to use current directory)");
            var caps = Directory.EnumerateDirectories(Directory.GetCurrentDirectory()).ToList();
            var d_tomo = Directory.CreateDirectory("Volume 0" + n_tomo);
            for (int i = 1; i < caps.Count + 1; i++)
            {
                var files = Directory.EnumerateFiles(caps[i-1]);
                foreach (var file in files)
                {
                    var fileinfo = new FileInfo(file);
                    string fileName = fileinfo.Name;
                    if (acceptedFormats.Contains(fileinfo.Extension.ToLower()))
                    {
                        File.Copy(file,
                            Path.Combine(d_tomo.FullName, i + fileName));
                    }
                }
            }
        }
    }
}
