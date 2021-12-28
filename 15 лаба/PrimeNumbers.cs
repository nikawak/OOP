using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_лаба
{
    partial class Observation
    {

        public void FindPrimeNumbers()
        {
            int n = 30;
            var nums = new List<int>();
            for (int i = 2; i < n; i++)
            {
                bool flag = true;
                for (int j = 2; j <= i/2 && flag; j++)
                {
                    if (i % j == 0 && i != j)
                    {
                        flag = false;
                    }
                }
                if (flag) nums.Add(i);
            }

            Thread.CurrentThread.Name = "Prime numbers thread";
            WhenWrite("\nThread Name: " + Thread.CurrentThread.Name);
            WhenWrite("\nThread State: " + Thread.CurrentThread.ThreadState);
            WhenWrite("\nThread Priority: " + Thread.CurrentThread.Priority);
            WhenWrite("\nThread Id: " + Thread.CurrentThread.ManagedThreadId + "\n");

            foreach (var N in nums)
            {
                WhenWrite(N.ToString() + " | ");
                Thread.Sleep(300);
            }
            WhenWrite("\n\n");
        }
    }
}
