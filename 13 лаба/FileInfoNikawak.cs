using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ValueTuple;

namespace _13_лаба
{
    internal static class FileInfoNikawak
    {
        
        public static string PathFile(FileInfo file)
        {
            new LogNikawak().WriteInLogFile(ActionFile.PathFile);
            return file.FullName;
        }
        public static string FileInfo(FileInfo file)
        {
            new LogNikawak().WriteInLogFile(ActionFile.FileInfo);
            string result = "";

            result += $"Name: {file.Name}\n"+
                $"Extesion: {Path.GetExtension(PathFile(file))}\n" +
                $"Size: {file.Length}";

            return result;
        }
        public static (DateTime, DateTime) DateFile(FileInfo file)
        {
            new LogNikawak().WriteInLogFile(ActionFile.DateFile);
            var tuple = (Create: file.CreationTimeUtc, LastChange: file.LastAccessTimeUtc);
            return tuple;
        }
    }
}
