using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_лаба
{
    partial class Observation
    {
        private static Barrier bar = new Barrier(2);
        //чётный
        public void EvenNumbers()
        {
            var n = 10;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    WhenWrite(i.ToString() + " |");
                }
                //Thread.Sleep(100);
                //bar.SignalAndWait();
            }
        }

    }
}
