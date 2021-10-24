using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace _8_лаба
{
    class Program
    {
        static void Main(string[] args)
        {
            //............//ИСПОЛЬЗОВАНИЕ (+) (==) (>) (-)//............//
            
            Console.WriteLine("Создание первого массивa A");
            Array<int> a = Array<int>.Init();
            Console.WriteLine("Создание второго массивa B");
            Array<int> b = Array<int>.Init();

            Console.Write($"A: "); a.Print();
            Console.Write($"\nB: "); b.Print();

            if (a == b) Console.WriteLine("\nA == B : true\n");
            else Console.WriteLine("\nA == B : false\n");

            Console.Write($"C=A+B: ");
            Array<int> c = a + b;
            c.Print();
            c -= 5;
            Console.Write("\n\nC-5:  ");
            c.Print();

            if(c>-2) Console.WriteLine($"\n\nC>-2 : true");
            else Console.WriteLine($"C>-2 : false");



            //............//МЕТОДЫ РАСШИРЕНИЯ ИЗ ЗАДАНИЯ + ДАТА + ОБЪЕКТ//............//
            //Console.WriteLine(new ArrInt.Date());
            //Console.WriteLine($"\nПользователь {ArrInt.Owner.name} c ID: {ArrInt.Owner.ID}");
            //Console.WriteLine($"Разница между max и min в массиве С: {c.Difference()}\nСумма элементов массива C: {c.Sum()}");


            //............//МЕТОДЫ РАСШИРЕНИЯ ИЗ ВАРИАНТА//............//
            Console.Write($"Удаление первых пяти эл. массива С: ");
            c = c.Del5El();
            c.Print();

            Console.WriteLine();
            var d = new Array<char>("\nМоя большая и полная строка\n".ToCharArray());
            d.Print();

            char[] e = d.DelAllVowals();
            var f = new Array<char>(e);
            f.Print();


            try
            {
                Console.WriteLine("Сколько создать объектов: ");
                int size = int.Parse(Console.ReadLine());
                if (size < 0)
                    throw new Exception("Размер списка не может быть отрицательным");

                Array<Car> cars = new Array<Car>();
                for (int i = 0; i < size; i++)
                {
                    cars = cars.Add(new Car($"Tesla {i}"));
                }
                for (int i = 0; i < cars.Size; i++)
                {
                    Console.WriteLine(cars[i] + "\n");
                }


                cars.WriteInFile("file.txt");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }
    }
}
