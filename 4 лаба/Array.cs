using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_лаба
{
    partial class Array<T>
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
        //private Array array;
        //private T val;


        //............//ИНДЕКСАТОР//............//
        public T this[int index]
        {
            get { return array[index]; }
            //val = value;
            set { array[index] = value; }
            
        }

        //............//МЕТОДЫ ИНИЦИАЛИЗАЦИИ И ВЫВОДА//............//
        public static Array<int> InitInt()
        {
            Console.Write("Enter size: ");
            var YourSize = int.Parse(Console.ReadLine());
            Console.Write("Enter range: ");
            var range = int.Parse(Console.ReadLine());

            Array<int> arr = new(YourSize);
            var rand = new Random();

            for (int i = 0; i < arr.Size; i++)
            {
                arr[i] = rand.Next(range);
            }
            return arr;
        }
        public void Print()
        {
            if (this.GetType() == typeof(_4_лаба.Array<int>))
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write(this[i] + " ");
                }
            }
            else if(this.GetType() == typeof(_4_лаба.Array<char>))
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write(this[i] + " ");
                }
            }

        }
      

        //............//ПЕРЕГРУЗКА ОПЕРАТОРОВ//............//
        public static Array<T> operator +(Array<T> arr1, Array<T> arr2)
        {
            var arr = new Array<T>(arr1.size + arr2.size);

            for (int i = 0; i < arr1.size; i++)
            {
                arr[i] = arr1[i];
            }
            for (int i = 0; i < arr2.size; i++)
            {
                arr[arr1.size + i] = arr2[i];
            }
            return arr;
        }


        public static Array<int> operator -(Array<T> arr, int value)
        {
            Array<int> a = new(arr.size);

            for (int i = 0; i < arr.Size; i++)
            {
                a[i] = (int)(object)arr[i] - value;
            }
            return a;
        }


        public static bool operator ==(Array<T> arr1, Array<T> arr2)
        {
            bool res = false;
            if (arr1.size == arr2.size)
            {
                int size = arr1.size;
                for (int i=0;i<size;i++)
                {
                    res = (int)(object)arr1[i] == (int)(object)arr2[i] ? true : false;
                    if (!res)
                        return res;
                }
            }
            return res;
        }
        public static bool operator !=(Array<T> arr1, Array<T> arr2)
        {
            if (arr1 == arr2)
                return false;
            else return true;
        }
       

        public static bool operator >(Array<T> arr, int elem)
        {
            bool res = false;
            for(int i=0;i<arr.size;i++)
            {
                res = elem == (int)(object)arr[i] ? true : false;
                if (res)
                    return true;
            }
            return res;
        }
        public static bool operator <(Array<T> arr, int elem)
        {
            if (arr > 7)
                return false;
            else return true;
        }
    }
}
