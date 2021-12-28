using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;

namespace _13_лаба
{
    internal class FileManagerNikawak
    {
        public static void FirstTask(DriveInfo disk)
        {
            
            DirectoryInfo main = disk.RootDirectory;
            var files = main.GetFiles();
            var dirs = main.GetDirectories();
            string result = "";

            if (files.Length > 0)
                foreach (var item in files)
                    result += item + " | ";

            if (dirs.Length > 0)
                foreach (var item in dirs)
                    result += item + " | ";

            if (!new DirectoryInfo(@"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect").Exists)
            {
                //Thread.Sleep(2000);
                var inspect = Directory.CreateDirectory(@"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect");
                //Thread.Sleep(3000);
                using (FileStream fs = new FileStream(@"inspect\diskInfo.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(result);
                    }
                }

                //Thread.Sleep(1000);
                File.Copy("inspect\\diskInfo.txt", "inspect\\secondFileDiskInfo.txt", true);
                //Thread.Sleep(1000); //прикол
                File.Delete("inspect\\diskInfo.txt");
                new LogNikawak("inspect", @"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect").WriteInLogFile(ActionFile.FirstTask);
            }
        }
            
        public static void SecondTask(DirectoryInfo dir, string extension)
        {
            
            var d = Directory.CreateDirectory("FilesNikawak");


            var list = new List<FileInfo>();
            var files = dir.GetFiles();
            new LogNikawak("FilesNikawak", dir.Name + "\\FilesNikawak").WriteInLogFile(ActionFile.SecondTask);
            foreach (var item in files)
            {
                list.AddRange(files.Where(x => x.Extension == extension));
            }
            foreach (var item in list)
                File.Copy(item.FullName, d.FullName + "\\" + item.Name);
            Directory.Move("FilesNikawak", dir.Name + "\\FilesNikawak");

        }

        public static void ThirdTask()
        {
            new LogNikawak("inspect.zip", @"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect\inspect.zip").WriteInLogFile(ActionFile.ThirdTask);
            //ZipFile.CreateFromDirectory(@"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect", @"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect\inspect.zip");
            //ZipFile.ExtractToDirectory(@"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect\inspect.zip", @"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\inspect.zip");
        }
    }
}
