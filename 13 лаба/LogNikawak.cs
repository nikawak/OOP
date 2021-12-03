using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_лаба
{
    internal class LogNikawak
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }
        private string path;
        public string Path
        {
            get { return path; }
            set { if (!string.IsNullOrEmpty(value)) path = value; }
        }

        public static string LogPath { get; } = @"D:\Programming\Лабы\oop\13 лаба\bin\Debug\net6.0\logNikawak.txt";
        public DateTime Date { get; private set; }
        public ActionFile Action { get; private set; }

        public LogNikawak()
        {
            this.Date = DateTime.Now;
        }
        public LogNikawak(string Name, string Path):this()
        {
            name = Name;
            path = Path;
        }


        public void WriteInLogFile(ActionFile action)
        {
            using (FileStream fs = new FileStream(LogPath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    if(!string.IsNullOrEmpty(path)&&!string.IsNullOrEmpty(name))
                        sw.WriteLine($"Time of Action: {Date} Action: {action} File: {name} Path: {path}");
                    else
                        sw.WriteLine($"Time of Action: {Date} Action: {action}");
                }
            }
            
        }
        public static string[] ReadFromLogFile()
        {
            using(FileStream fs = new FileStream(LogPath,FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    string result = sr.ReadToEnd();
                    string[] lines = result.Split('\n');
                    return lines;
                }
            }
        }
        public static string FindForHourAgo(int Hours)
        {
            int i = 0;
            var lines = ReadFromLogFile();
            string res = "";
            foreach (var line in lines)
            {
                string[] words = line.Split(' ');
                if (words.Length < 2) continue;

                string[] tt = words[3].Split('.');
                string[] t = words[4].Split(':');

                if (Convert.ToInt32(tt[0]) == DateTime.Now.Day && Convert.ToInt32(tt[1]) == DateTime.Now.Month && Convert.ToInt32(tt[2]) == DateTime.Now.Year && DateTime.Now.Hour - Hours < Convert.ToInt32(t[0]))
                    Console.WriteLine(line);
            }
            return res;
        }

    }
    enum ActionFile : byte
    {
        FreeSpaceOnDisk,
        DisksInformation,
        FileSystem,
        PathFile,
        FileInfo,
        DateFile,
        NumOfFiles,
        DateDir,
        NumOfSubDir,
        ListParentDir,
        FirstTask,
        SecondTask,
        ThirdTask
    }
    
}
