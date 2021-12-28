using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_лаба
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var obs = new Observation();


            Console.WriteLine("class Observation\nSpace - write in file | Enter - write on console");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    obs.WhenWrite += Console.Write;
                    break;
                case ConsoleKey.Spacebar:

                    FileStream fs = new FileStream("ProcessInfo.txt", FileMode.OpenOrCreate);
                    StreamWriter sw = new(fs);
                    obs.WhenWrite += sw.Write;
                    break;
            }
            if (true)
            {
                obs.ProcessInfo();
                obs.DomenInfo();
            }


            Thread prime = new Thread(obs.FindPrimeNumbers);
            prime.Priority = ThreadPriority.Normal;
            if (false)
            {
                prime.Start();
                prime.Join();
            }


            ThreadStart ts1 = new ThreadStart(obs.OddNumbers);
            ThreadStart ts2 = new ThreadStart(obs.EvenNumbers);
            Thread odd1 = new Thread(ts1);
            Thread even1 = new Thread(ts2);

            if (false)
            {
                odd1.Start();
                even1.Start();
                //odd1.Join();
                //odd1.Join();
            }

            if (true)
            {
                TimerCallback tcb = new TimerCallback(Observation.Ghoul);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nЕсли бы кто-то по какой-то причине написал историю со мной в главной роли,\n" +
                    " то это непременно была бы трагедия.\tХайсе Сасаки / Канеки Кен\n\n\n");

                Console.WriteLine($"             1000 - 7");
                Console.ReadKey();

                Timer timer1 = new Timer(tcb, null, 0, 300);
                Timer timer2 = new Timer(tcb, null, 3600, 133);
                Timer timer3 = new Timer(tcb, null, 6900, 32);
                Thread.Sleep(9120);
            }

            //Process[] procList = Process.GetProcesses();

            //AppDomain newD = AppDomain.CreateDomain("New");
            //newD.Load("имя сборки");
            //AppDomain.Unload(newD);


            //Thread th = new Thread((new int()method);
            //th.Start();

            //WaitOne() 
            //ReleaseMutex() 

            //obj синхр. N потокам
        }
    }
}







