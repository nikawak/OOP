using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_лаба
{
    partial class Array<T> : IForGeneric<T> where T : struct
    {
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


        public static Array<T> operator -(Array<T> arr, T value)
        {
            Array<T> a = new(arr.size);

            if (typeof(T) == typeof(double))
            {
                for (int i = 0; i < arr.Size; i++)
                {
                    a[i] = (T)(object)((double)(object)arr[i] - (double)(object)value);

                }
            }
            if (typeof(T) == typeof(int))
            {
                for (int i = 0; i < arr.Size; i++)
                {
                    a[i] = (T)(object)((int)(object)arr[i] - (int)(object)value);

                }
            }
            return (_8_лаба.Array<T>)(object)a;
        }


        public static bool operator ==(Array<T> arr1, Array<T> arr2)
        {
            bool res = false;
            if (arr1.size == arr2.size)
            {
                int size = arr1.size;
                if (typeof(T) == typeof(double))
                {
                    for (int i = 0; i < size; i++)
                    {
                        res = (double)(object)arr1[i] == (double)(object)arr2[i] ? true : false;
                        if (!res)
                            return res;
                    }
                }
                if (typeof(T) == typeof(int))
                {
                    for (int i = 0; i < size; i++)
                    {
                        res = (int)(object)arr1[i] == (int)(object)arr2[i] ? true : false;
                        if (!res)
                            return res;
                    }
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


        public static bool operator >(Array<T> arr, T elem)
        {
            bool res = false;
            if (typeof(T) == typeof(int))
            {
                for (int i = 0; i < arr.size; i++)
                {
                    res = (int)(object)elem == (int)(object)arr[i] ? true : false;
                    if (res)
                        return true;
                }
            }
            if (typeof(T) == typeof(double))
            {
                for (int i = 0; i < arr.size; i++)
                {
                    res = (double)(object)elem == (double)(object)arr[i] ? true : false;
                    if (res)
                        return true;
                }
            }
            return res;
        }
        public static bool operator <(Array<T> arr, T elem)
        {
            if (arr > elem)
                return false;
            else return true;
        }
    }
}
