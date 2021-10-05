using System;

namespace _5_лаба
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanDrive person = new Human("Макар", 2000);
            ICarManagement[] vehicle = { new Car("Tesla X"), new Transformer("Вадим", "RTX1080", 680), new Bike("Bk1000") };

            foreach (Vehicle item in vehicle)
            {
                person.Driving(item);
                Console.WriteLine("\n" + new String('-', 40));
            }

            Icloneable user1 = new User();
            user1.DoClone();
            BaseClone user2 = new User();
            user2.DoClone(false);


            Vehicle a = new Car();
            Console.Write("\nCar == Car: ");
            Console.Write(a.Equals(new Car()));
            Console.Write("\nCar == Bike: ");
            Console.WriteLine(a.Equals(new Bike()));
            Console.ReadKey();
            Console.Clear();

            Army A = new Army("Альфа");
            A = A.Add(new Transformer("Вадим", "Автобот1", 680));
            A = A.Add(new Transformer("Егор", "Автобот2", 720));
            A = A.Add(new Transformer("Крис", "Автобот3", 330));
            A = A.Add(new Human("Павел", 1995));
            Army B = new Army("Омега");
            B = B.Add(new Transformer("Вадим", "Десиптикон0001", 680));
            B = B.Add(new Transformer("Егор", "Десиптикон1000", 720));
            B = B.Add(new Transformer("Крис", "Десиптикон2000", 330));
            B = B.Add(new Human("Павел", 1995));
            A = A.Del("Крис");

            //..........//ПОИСК//..........//
            IIntelligentCreature tr = A.Find(680);
            Console.WriteLine(tr + "\n");
            Console.WriteLine(A.arr[2]);

            A = A.FindPower(300000, 700000);
            B = B.FindPower(300000, 400000);
            //..........//ВЫВОД//..........//
            A.Print();
            B.Print();

            //..........//СТРУКТУРА И ПЕРЕЧИСЛЕНИЕ//..........//
            Console.ReadKey();
            Console.Clear();
            var today = new Nadeya();
            today.GoodDay = true;
            //today.GoodDay = false;

            if (today.GoodDay == true)
                today.State = MyState.Happy;
            else today.State = MyState.DeadInside;

            Console.WriteLine(today);
            
        }
    }
}
