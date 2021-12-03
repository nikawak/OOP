using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_лаба
{
    internal class DirInfoNikawak
    {
        public static int NumOfFiles(string path)
        {
            new LogNikawak().WriteInLogFile(ActionFile.NumOfFiles);
            return Directory.GetFiles(path).Length;
        }
        public static DateTime DateDir(string path)
        {
            new LogNikawak().WriteInLogFile(ActionFile.DateDir);
            return Directory.GetCreationTime(path);
        }
        public static int NumOfSubDir(string path)
        {
            new LogNikawak().WriteInLogFile(ActionFile.NumOfSubDir);
            return Directory.GetDirectories(path).Length;
        }
        public static List<DirectoryInfo> ListParentDir(string path)
        {
            new LogNikawak().WriteInLogFile(ActionFile.ListParentDir);
            var list = new List<DirectoryInfo>();
            DirectoryInfo son = new DirectoryInfo(path);

            while (son.Parent != null)
            {
                son = son.Parent;
                list.Add(son);
            }
            return list;
        }

    }
}
