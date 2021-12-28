using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_лаба
{
    public delegate void WriteIn(string info);
    partial class Observation
    {
        public event WriteIn WhenWrite;
        private StringBuilder Info;
        public void ProcessInfo()
        {
            Info = new StringBuilder();
            Info.Append("Info about processes: " + "\n");
            Info.Append(new string('=',30)+"\n");
            var allProc = Process.GetProcesses();
            foreach(var proc in allProc)
            {
                Info.Append("Process name: "+proc.ProcessName.ToString()+"\n");
                Info.Append("ID: " + proc.Id.ToString()+"\n");
                Info.Append("Process priority: ");
                try
                {
                    Info.Append(proc.BasePriority.ToString() + "\n");
                }
                catch
                {
                    Info.Append("access denied\n");
                }
                Info.Append("Process start time: ");
                try
                {
                    Info.Append(proc.StartTime.ToString() + "\n");
                }
                catch
                {
                    Info.Append("access denied\n");
                }
                Info.Append("Processor time for this process: ");
                try
                {
                    Info.Append(proc.TotalProcessorTime.ToString() + "\n");
                }
                catch
                {
                    Info.Append("access denied\n");
                }
                Info.Append(new string('-', 30) + "\n");
            }
            Info.Append("\n");
            WhenWrite(Info.ToString());
        }
        public void DomenInfo()
        {
            Info = new StringBuilder();

            AppDomain domain = AppDomain.CurrentDomain;
            Info.Append("\nCurrent domain: " + domain.FriendlyName);
            Info.Append("\nBase directory: " + domain.BaseDirectory);
            Info.Append("\nConfigurations(setup): " + domain.SetupInformation);
            Info.Append("\nAssemblies:\n");
            foreach (var ass in domain.GetAssemblies())
                Info.Append(" - "+ass.GetName().Name+'\n');
            WhenWrite(Info.ToString());
        }

    }
}
