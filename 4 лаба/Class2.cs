using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_лаба
{
    //............//КЛАСС ДЛЯ МЕТОДОВ РАСШИРЕНИЯ//............//
    static class StaticOperation
    {
        public static long Sum(this Array<int> arr)
        {
            long sum=0;
            for(int i=0;i<arr.Size;i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public static int Difference(this Array<int> arr)
        {
            int max = arr[0], min = arr[0];
            for(int i=0;i<arr.Size;i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                else if (arr[i] < min)
                    min = arr[i];
            }
            return max - min;
        }

        public static Array<int> Del5El(this Array<int> arr)
        {
            Array<int> arr2 = new Array<int>(arr.Size - 5);
            for (int i = 0; i < arr.Size - 5; i++)
            {
                arr2[i] = arr[i + 5];
            }
            return arr2;
        }

        public static char[] DelAllVowals(this Array<char> a)
        {
            string vowals = "ауоыиэяюёе";
            byte[] delMe = new byte[a.Size];
            int countV = 0;

            for (byte i = 0; i < a.Size; i++)
            {
                foreach (char c in vowals)
                {
                    if (a[i] == c)
                    {
                        delMe[countV] = i;
                        countV++;
                    }
                }
            }

            char[] b = new char[a.Size - countV];

            for (int i = 0, count = 0, j = 0; i < a.Size; j++, i++)
            {
                if (delMe[count] != i)
                {
                    b[j] = a[i];
                }
                else { j--; count++; }
            }
            return b;
        }
    }
}
