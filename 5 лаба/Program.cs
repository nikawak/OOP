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
            A = A.Add(new Human("Павел", 1995));
            A = A.Add(person);

            Army B = new Army("Омега");
            B = B.Add(new Transformer("Вадим", "Десиптикон0001", 680));
            B = B.Add(new Transformer("Егор", "Десиптикон1000", 720));
            B = B.Add(new Transformer("Крис", "Десиптикон2000", 330));
            B = B.Add(new Human("Павел", 1995));
            B = B.Del("Вадим");


            //..........//ПОИСК//..........//
            //IIntelligentCreature tr = ArmyControl.Find(A, 680);
            //Console.WriteLine(tr + "\n");

            //A = ArmyControl.FindPower(A,300000, 700000);
            //B = ArmyControl.FindPower(B,300000, 400000);
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



            string path = "file.txt";
            Army C = ArmyControl.InitFromFile(new Army("Дельта"), (path));
            C.Print();

            string pathJson = "Json.json";
            Army D = ArmyControl.InitFromJson(pathJson);
            D.Print();
        }
    }
}
