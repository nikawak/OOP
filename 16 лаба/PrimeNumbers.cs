using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_лаба
{
    partial class Program
    {

        public static void FindPrimeNumbers(int iii)
        {
            int n = 50000;
            var nums = new List<int>();
            for (int i = 2; i < n; i++)
            {
                bool flag = true;
                for (int j = 2; j <= i / 2 && flag; j++)
                {
                    if (i % j == 0 && i != j)
                    {
                        flag = false;
                    }
                }
                if (flag) nums.Add(i);
            }
            foreach(var num in nums)
            {
                Console.WriteLine(num);
            }
        }
    }
}
