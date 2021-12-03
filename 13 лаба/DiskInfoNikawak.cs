using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_лаба
{
    internal static class DiskInfoNikawak
    {
        private static DriveInfo[] disks = DriveInfo.GetDrives();
        public static long FreeSpaceOnDisk(DriveInfo disk)
        {
            new LogNikawak().WriteInLogFile(ActionFile.FreeSpaceOnDisk);

            return disk.AvailableFreeSpace;
        }
        public static string FileSystem(DriveInfo disk)
        {
            new LogNikawak().WriteInLogFile(ActionFile.FileSystem);
            return disk.DriveFormat;
        }
        public static string DisksInformation()
        {
            new LogNikawak().WriteInLogFile(ActionFile.DisksInformation);
            string result = "";

            foreach(var disk in disks)
            {
                result +=
                    $"Name: {disk.Name}\n" +
                    $"Drive type: {disk.DriveType}" +
                    $"Disk is ready: {disk.IsReady}\n";
                if (!disk.IsReady) continue;

                result +=
                    $"Type: {disk.DriveType}\n" +
                    $"Total size: {disk.TotalSize}\n" +
                    $"Total size: {disk.AvailableFreeSpace}\n" +
                    $"Volume label: {disk.VolumeLabel}\n"; //метка тома
            }
            return result;
        }
    }
}
