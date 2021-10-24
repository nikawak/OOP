using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    class FileLogger
    {
        public static void Write(string path, ExceptionTest exe)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(exe.LogInfo());
                }
            }


        }
    }
}
