using System;
using ArrInt = _4_лаба.Array<int>;
using ArrChar = _4_лаба.Array<char>;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace _4_лаба
{
    class Program
    {
        static void Main(string[] args)
        {
            //............//ИСПОЛЬЗОВАНИЕ (+) (==) (>) (-)//............//
            Console.WriteLine("Создание первого массивa A");
            var a = ArrInt.InitInt();
            Console.WriteLine("Создание второго массивa B");
            var b = ArrInt.InitInt();
            Console.Write($"A: "); a.Print();
            Console.Write($"\nB: "); b.Print();

            if (a == b) Console.WriteLine("\nA == B : true\n");
            else Console.WriteLine("\nA == B : false\n");

            Console.Write($"C=A+B: ");
            ArrInt c = a + b;
            c.Print();
            c -= 5;
            Console.Write("\n\nC-5:  ");
            c.Print();

            if(c>-2) Console.WriteLine($"\n\nC>-2 : true");
            else Console.WriteLine($"C>-2 : false");



            //............//МЕТОДЫ РАСШИРЕНИЯ ИЗ ЗАДАНИЯ + ДАТА + ОБЪЕКТ//............//
            Console.WriteLine(new ArrInt.Date());
            Console.WriteLine($"\nПользователь {ArrInt.Owner.name} c ID: {ArrInt.Owner.ID}");
            Console.WriteLine($"Разница между max и min в массиве С: {c.Difference()}\nСумма элементов массива C: {c.Sum()}");


            //............//МЕТОДЫ РАСШИРЕНИЯ ИЗ ВАРИАНТА//............//
            Console.Write($"Удаление первых пяти эл. массива С: ");
            c = c.Del5El();
            c.Print();

            Console.WriteLine();
            var d = new ArrChar("\nМоя большая и полная строка\n".ToCharArray());
            d.Print();

            char[] e = d.DelAllVowals();
            var f = new ArrChar(e);
            f.Print();
        }
    }
}
