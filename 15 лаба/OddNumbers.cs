using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_лаба
{
    partial class Observation
    {
        //нечётный
        public void OddNumbers()
        {
            var n = 10;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    WhenWrite(i.ToString() + " |");
                }
                //Thread.Sleep(100);
                //bar.SignalAndWait();

            }
        }
    }
}
