using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _8_лаба
{
    partial class Array<T> : IForGeneric<T> where T :struct
    {
        /////КОНСТРУКТОР ДЛЯ ЗАДАНИЯ РАЗМЕРА или ИНИЦАИЛИЗАЦИИ СТРОК/////
        public Array(int size)
        {
            this.array = new T[size];
            this.size = size;
        }
        public Array(T[] symbol)
        {
            size = symbol.Length;
            this.array = new T[size];
            for (int i=0;i<size;i++)
            {
                array[i] = symbol[i];
            }
        }
        public Array() {}

        /////ПОЛЯ И СВОЙСТВА/////
        private int size;
        public int Size
        {
            get { return size; }
        }
        private T[] array;


        //............// ИНДЕКСАТОР //............//
        public T this[int index]
        {
            get { return array[index]; }
            //val = value;
            set { array[index] = value; }            
        }

        //............// МЕТОДЫ //............//
        public static Array<T> Init()
        {
            
            Console.Write("Enter size: ");
            var YourSize = int.Parse(Console.ReadLine());
            Console.Write("Enter range: ");
            var range = int.Parse(Console.ReadLine());

            Array<T> arr = new(YourSize);
            var rand = new Random();

            if (typeof(T) == typeof(int))
            {
                for (int i = 0; i < arr.Size; i++)
                {
                    arr[i] = (T)(object)(rand.Next(range));
                }
            }

            if (typeof(T) != typeof(int) && typeof(T) != typeof(char))
            {
                for (int i = 0; i < arr.Size; i++)
                {
                    arr[i] = (T)(object)((rand.Next(10000) * range) / Math.Pow(10, 4));
                }
            }
            
            return arr;
        }
        public Array<Car> Add(Car n)
        {
            Array<Car> cars = new Array<Car>(Size + 1);
            for (int i=0;i<Size;i++)
            {
                cars[i] = (Car)(object)this[i];
            }
            cars[Size] = n;
            return cars;
        }
        public Array<T> DeleteForNum(T num)
        {
            Array<T> arr2 = new Array<T>(Size - 1);
            for (int i = 0; i < Size - 1; i++)
            {
                if ((decimal)(object)array[i] != (decimal)(object)num)
                {
                    arr2[i] = array[i];
                }
            }
            return arr2;
        }
        public void Print()
        {
            if (typeof(T) == typeof(double))
            {
                for (int i = 0; i < size; i++)
                {
                    double zxc = (double)(object)this[i];

                    zxc = (double)(int)(zxc * 100) / (double)100;

                    Console.Write(zxc + " ");
                }
            }
            if (typeof(T) == typeof(int))
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write(this[i] + " ");
                }
            }
            if (typeof(T) == typeof(char))
            {
                for(int i=0;i<size;i++)
                {
                    Console.Write(this[i] + " ");
                }
            }
        }       
        public void WriteInFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 0; i < Size; i++)
                {
                    sw.WriteLine(this[i].ToString());
                    sw.WriteLine();
                }

            }

        }
    }
}
